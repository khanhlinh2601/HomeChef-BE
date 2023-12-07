using FirebaseAdmin.Auth;
using HC.Application.Common.Exceptions;
using HC.Application.Common.Interfaces;
using HC.Domain.Dto.Requests;
using HC.Domain.Dto.Responses;
using HC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HC.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public AuthService(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public string GenerateToken(UserResponse user)
        {
            return _tokenService.GetToken(user);
        }

        public async Task<FirebaseToken> GetFirebaseTokenAsync(string token)
        {
            return await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(token);
        }


        public async Task<LoginResponse> GetUserByFirebaseTokenAsync(LoginRequest loginRequest)
        {
            try
            {
                FirebaseToken firebaseToken = await GetFirebaseTokenAsync(loginRequest.IdToken);
                //get info from firebase token
                var email = firebaseToken.Claims.GetValueOrDefault("email")?.ToString();
                var phone = firebaseToken.Claims.GetValueOrDefault("phone_number")?.ToString();
                var birthday = firebaseToken.Claims.GetValueOrDefault("birthday")?.ToString();
                var avatar = firebaseToken.Claims.GetValueOrDefault("picture")?.ToString();
                var name = firebaseToken.Claims.GetValueOrDefault("name")?.ToString();

                LoginResponse loginResponse = new();
                if (email is null || phone is null)
                {
                    throw new BadRequestException("Invalid Token");
                }
                var role = await _unitOfWork.Role.GetByIdAsync(loginRequest.RoleId);
                if (role is null)
                {
                    throw new BadRequestException("Role invalid");
                }

                var user = await _unitOfWork.User.GetOneByConditionAsync(
                    expression: x => x.Email == email || x.Phone == phone,
                    includeProperties: new Expression<Func<User, object>>[] { x => x.Role }
                    );
                if (user is null)
                {
                    loginResponse.IsFirstTime = true;
                    User newUser = new User()
                    {
                        Email = email ?? "",
                        Phone = phone ?? "",
                        AvatarUrl = avatar ?? "",
                        FullName = name ?? "",
                        RoleId = role.Id,
                        FcmToken = new List<string>() { loginRequest.FcmToken },
                    };
                    await _unitOfWork.User.CreateAsync(newUser);
                    UserResponse userResponse = new UserResponse(newUser);
                    loginResponse.User = userResponse;
                    loginResponse.Token = GenerateToken(userResponse);
                }
                else
                {
                    loginResponse.IsFirstTime = false;
                    if (!user.FcmToken.Contains(loginRequest.FcmToken))
                    {
                        user.FcmToken.Add(loginRequest.FcmToken);
                        await _unitOfWork.User.UpdateAsync(user);
                    }
                    UserResponse userResponse = new UserResponse(user);
                    loginResponse.User = userResponse;
                    loginResponse.Token = GenerateToken(userResponse);
                }

                return loginResponse;

            }
            catch (Exception e)
            {
                throw new BadRequestException(e.Message);
            }

        }

        public async Task<bool> Logout(Guid userId, string fcmToken)
        {
            var user = await _unitOfWork.User.GetByIdAsync(userId);
            if (user is null)
            {
                throw new UnauthorizedException("You do not have permission");
            }
            user.FcmToken.Remove(fcmToken);
            await _unitOfWork.User.UpdateAsync(user);
            return true;
        }

        public async Task<UserResponse> Get(Guid id)
        {
            var user = await _unitOfWork.User.GetOneByConditionAsync(id, new Expression<Func<User, object>>[] { x => x.Role });
            if (user is null)
            {
                throw new BadRequestException($"{nameof(user)} is null");

            }
            return new UserResponse(user);
        }

        public async Task<UserResponse> Update(Guid id, UpdateUserRequest userRequest)
        {
            User user = await _unitOfWork.User.GetOneByConditionAsync(id, new Expression<Func<User, object>>[] { x => x.Role });

            if (user is null)
            {
                throw new BadRequestException("user invalid");
            }
            user.Email = userRequest.Email ?? "";
            user.FullName = userRequest.FullName ?? "";
            user.AvatarUrl = userRequest.AvatarUrl ?? "";
            user.Phone = userRequest.Phone ?? "";
            user.Birthday = userRequest.Birthday;

            await _unitOfWork.User.UpdateAsync(user);
            return new UserResponse(user);
        }




    }
}
