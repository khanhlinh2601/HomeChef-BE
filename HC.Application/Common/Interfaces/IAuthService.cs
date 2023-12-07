using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin.Auth;
using HC.Domain.Dto.Requests;
using HC.Domain.Dto.Responses;

namespace HC.Application.Common.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(UserResponse user);
        Task<FirebaseToken> GetFirebaseTokenAsync(string token);
        Task<LoginResponse> GetUserByFirebaseTokenAsync(LoginRequest loginRequest);
        Task<bool> Logout(Guid userId, string fcmToken);
        Task<UserResponse> Get(Guid id);
        Task<UserResponse> Update(Guid id, UpdateUserRequest userRequest);
    }
}
