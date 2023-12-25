using FirebaseAdmin.Auth;
namespace HC.Application.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;

    private readonly IUserService _userService;
    public AuthService(ITokenService tokenService, IUserService userService)
    {
        _tokenService = tokenService;
        _userService = userService;
    }
    public string GenerateToken(UserResponse user)
    {
        return _tokenService.GetTokenAsync(user);
    }

    public async Task<FirebaseToken> GetFirebaseTokenAsync(string token)
    {
        return await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(token);
    }

    public async Task<UserResponse> Get(Guid userId)
    {
        var user = await _userService.GetById(userId);
        if (user is null)
        {
            throw new UnauthorizedException("You do not have permission");
        }
        return user.Adapt<UserResponse>();
    }


    public async Task<LoginResponse> GetUserByFirebaseTokenAsync(LoginRequest request)
    {
        try
        {
            FirebaseToken firebaseToken = await GetFirebaseTokenAsync(request.IdToken);
            //get info from firebase token
            var email = firebaseToken.Claims.GetValueOrDefault("email")?.ToString();
            var phone = firebaseToken.Claims.GetValueOrDefault("phone_number")?.ToString();
            var birthday = DateTime.Parse(firebaseToken.Claims.GetValueOrDefault("birthday")?.ToString());
            var avatar = firebaseToken.Claims.GetValueOrDefault("picture")?.ToString();
            var name = firebaseToken.Claims.GetValueOrDefault("name")?.ToString();
            var user = await _userService.GetByEmailAndPhone(email, phone);

            if (user is null)
            {
                var userId = await _userService.Create(new CreateUserRequest()
                {
                    Email = email ?? "",
                    Phone = phone ?? "",
                    Birthday = birthday,
                    AvatarUrl = avatar,
                    FullName = name,
                    FcmToken = request.FcmToken,
                    Role = request.Role
                });
                var userResponse = await _userService.GetById(userId);
                return new LoginResponse()
                {
                    IsFirstTime = true,
                    Token = GenerateToken(userResponse),
                    User = userResponse
                };
            }
            await _userService.UpdateFcmToken(user.Id, request.FcmToken);
            return new LoginResponse()
            {
                IsFirstTime = false,
                Token = GenerateToken(user.Adapt<UserResponse>()),
                User = user.Adapt<UserResponse>()
            };
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }

    }

    public async Task<bool> Logout(Guid userId, string fcmToken)
    {
        var user = await _userService.GetById(userId);
        if (user is null)
        {
            throw new UnauthorizedException("You do not have permission");
        }
        await _userService.RemoveFcmToken(userId, fcmToken);
        return true;
    }

}