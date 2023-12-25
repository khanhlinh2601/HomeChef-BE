namespace HC.Application.Interfaces;

public interface IUserService : IScopedService
{
    Task<Guid> Create(CreateUserRequest request);
    Task<Guid> Update(Guid id, UpdateUserRequest request);
    Task<Guid> Delete(Guid id);
    Task<Guid> UpdateFcmToken(Guid id, string fcmToken);
    Task<Guid> RemoveFcmToken(Guid id, string fcmToken);
    Task<UserResponse> GetById(Guid id);
    Task<User> GetByEmailAndPhone(string? email, string? phone);
    Task<IEnumerable<UserResponse>> GetAll();
    Task<List<string>> GetFcmToken(Guid id);
}

