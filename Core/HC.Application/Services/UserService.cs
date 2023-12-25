using System.Linq.Expressions;

namespace HC.Application.Services;

public class UserService : IUserService
{
    private readonly IGenericRepository<User> _userRepository;

    public UserService(IGenericRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Create(CreateUserRequest request)
    {
        await ValidateUser(request);
        var entity = request.Adapt<User>();
        await _userRepository.CreateAsync(entity);
        return entity.Id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        var user = await GetUserById(id);
        await _userRepository.DeleteAsync(user.Id);
        return user.Id;
    }

    public Task<IEnumerable<UserResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<UserResponse> GetById(Guid id)
    {
        var user = await GetUserById(id);
        return user.Adapt<UserResponse>();
    }

    public async Task<Guid> Update(Guid id, UpdateUserRequest request)
    {
        var user = await GetUserById(id);
        await _userRepository.UpdateAsync(user);
        return user.Id;
    }

    public async Task<Guid> UpdateFcmToken(Guid id, string fcmToken)
    {
        var user = await GetUserById(id);
        user.FcmToken.Add(fcmToken);
        await _userRepository.UpdateAsync(user);
        return user.Id;
    }
    public async Task<User> GetByEmailAndPhone(string? email, string? phone)
    {
        var user = await _userRepository.GetOneByConditionAsync(
            expression: x => x.Email == email || x.Phone == phone,
            new Expression<Func<User, object>>[] { x => x.Role }
            );
        return user;
    }

    private async Task ValidateUser(CreateUserRequest request)
    {
        var user = await GetByEmailAndPhone(request.Email, request.Phone);
        if (user is not null)
        {
            throw new ConflictException("User is already exist");
        }


    }
    private async Task<User> GetUserById(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user is null)
        {
            throw new NotFoundException("User is not exist");
        }
        return user;
    }

    public async Task<Guid> RemoveFcmToken(Guid id, string fcmToken)
    {
        var user = await GetUserById(id);
        user.FcmToken.Remove(fcmToken);
        await _userRepository.UpdateAsync(user);
        return user.Id;
    }
    public async Task<List<string>> GetFcmToken(Guid id)
    {
        var user = await GetUserById(id);
        return user.FcmToken;
    }
}
