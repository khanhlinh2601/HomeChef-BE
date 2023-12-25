using FirebaseAdmin.Auth;

namespace HC.Application.Interfaces;

public interface IAuthService : IScopedService
{
    string GenerateToken(UserResponse user);
    Task<FirebaseToken> GetFirebaseTokenAsync(string token);
    Task<LoginResponse> GetUserByFirebaseTokenAsync(LoginRequest loginRequest);
    Task<bool> Logout(Guid userId, string fcmToken);
    Task<UserResponse> Get(Guid userId);
}

