using HC.Application.Common.Exceptions;
using HC.Application.Common.Interfaces;
using HC.Domain.Dto.Requests;
using HC.Domain.Dto.Responses;
using HC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HC.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(CreateUserRequest request)
        {
            try
            {
                var role = await _unitOfWork.Role.GetByIdAsync(request.RoleId);
                if (role is null)
                {
                    throw new BadRequestException("Role invalid");
                }

                var user = await _unitOfWork.User.GetOneByConditionAsync(
                    expression: x => x.Email == request.Email || x.Phone == request.Phone,
                    new Expression<Func<User, object>>[] { x => x.Role }
                    );
                if (user is not null)
                {
                    throw new BadRequestException("User is exist");
                }
                user = new User()
                {
                    Email = request.Email,
                    Phone = request.Phone,
                    RoleId = role.Id,
                    AvatarUrl = request.AvatarUrl,
                    Birthday = request.Birthday,
                    FcmToken = new List<string> { request.FcmToken },
                    FullName = request.FullName,

                };
                if (role.Name.Equals("Chef"))
                {
                    await _unitOfWork.Chef.CreateAsync(new Chef()
                    {
                        User = user,
                        Wallet = 0
                    });
                }
                await _unitOfWork.User.CreateAsync(user);

                return await _unitOfWork.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
            
        }

        public async Task<bool> Update (Guid id, UpdateUserRequest request)
        {
            try
            {
                var user = await _unitOfWork.User.GetByIdAsync (id);
                if (user is null)
                {
                    throw new BadRequestException("User is not exist");
                }
                user.Email = request.Email ?? "";
                user.FullName = request.FullName ?? "";
                user.AvatarUrl = request.AvatarUrl ?? "";
                user.Phone = request.Phone ?? "";
                user.Birthday = request.Birthday;
                user.Chef.IdentityCard = request.IdentityCard ?? "";
                user.Chef.Biography = request.Biography ?? "";
                user.Chef.Districts = await HandleDistrict(request.DistrictIds ?? new List<Guid>());

                return await _unitOfWork.User.UpdateAsync(user) > 0;

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }

        public async Task<bool> Delete (Guid id)
        {
            return (await _unitOfWork.User.DeleteAsync(id)) != null;
        }

        public async Task<UserResponse> GetById(Guid id)
        {
            var user = await _unitOfWork.User
                .GetOneByConditionAsync(id, 
                new Expression<Func<User, object>>[] { x => x.Role, x => x.Chef  });
            return new UserResponse(user);
        }

        public async Task<IEnumerable<UserResponse>> GetAll()
        {
            var user = await _unitOfWork.User.GetAllAsync(
                includeProperties: new Expression<Func<User, object>>[] { x => x.Role }
                );
            IEnumerable<UserResponse> result = new List<UserResponse>();
            foreach (var u in user)
            {
                result.Append(new UserResponse(u));
            }
            return result;
        }

        private async Task<List<District>> HandleDistrict(List<Guid> districtIds)
        {
            List<District> districts = new List<District>();
            foreach (var id in districtIds)
            {
                var district = await _unitOfWork.District.GetByIdAsync(id);
                if (district is null)
                {
                    throw new BadRequestException("District is not exist");
                }
                districts.Add(district);
            }
            return districts;
        }

        



    }
}
