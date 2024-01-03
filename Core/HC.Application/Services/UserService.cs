using HC.Application.Common.Persistence;
using HC.Application.Specification;
using Microsoft.Extensions.Localization;

namespace HC.Application.Services;

public class UserService : IUserService
{
    
    private async Task ValidateUser(CreateUserRequest request)
    {
        var user = await GetByEmailAndPhone(request.Email, request.Phone);
        if (user is not null)
        {
            throw new ConflictException("User is already exist");
        }
    }
    private readonly IFeedbackService _feedbackService;
    private readonly IRepository<User> _userRepository;
    private readonly IStringLocalizer _t;

    public UserService(IRepository<User> userRepository, IStringLocalizer<UserService> t, IFeedbackService feedbackService)
    {
        _userRepository = userRepository;
        _t = t;
        _feedbackService = feedbackService;
    }
    public async Task<Guid> Create(CreateUserRequest request)
    {
        await ValidateUser(request);
        var entity = request.Adapt<CreateUserRequest, User>();
        await _userRepository.AddAsync(entity);
        return entity.Id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        _ = user ?? throw new NotFoundException(_t["User is not exist"]);
        await _userRepository.DeleteAsync(user);
        return user.Id;
    }

    public async Task<IEnumerable<UserResponse>> GetAll()
    {
        var users = await _userRepository.ListAsync();
        return users.Adapt<IEnumerable<UserResponse>>();
    }

    public async Task<IEnumerable<UserResponse>> GetAllChef()
    {
        var users = await _userRepository.ListAsync(new UserByRoleSpec(Role.CHEF));
        var response = users.Adapt<IEnumerable<UserResponse>>();
        foreach (var user in response)
        {
            user.Feedbacks = await _feedbackService.GetByChefId(user.Id);
            user.Rating = user.Feedbacks.Average(x => x.Rating);
            user.TotalFeedback = user.Feedbacks.Count();
        }
        return response;
    }

    public async Task<IEnumerable<UserResponse>> GetAllCustomer()
    {
        var users = await _userRepository.ListAsync(new UserByRoleSpec(Role.CUSTOMER));
        return users.Adapt<IEnumerable<UserResponse>>();
    }

    public async Task<User> GetByEmailAndPhone(string? email, string? phone)
    {
        return await _userRepository.FirstOrDefaultAsync(new UserByEmailPhoneSpec(email, phone));
    }

    public async Task<UserResponse> GetById(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        _ = user ?? throw new NotFoundException(_t["User is not exist"]);
        
        var response =  user.Adapt<UserResponse>();

        if (user.Role == Role.CHEF)
        {
            response.Feedbacks = await _feedbackService.GetByChefId(response.Id);
            response.Rating = response.Feedbacks.Average(x => x.Rating);
            response.TotalFeedback = response.Feedbacks.Count();
        }
        return response;
    }

    public async Task<List<string>> GetFcmToken(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        _ = user ?? throw new NotFoundException(_t["User is not exist"]);
        return user.FcmToken;
    }

    public async Task<Guid> RemoveFcmToken(Guid id, string fcmToken)
    {
        var user = await _userRepository.GetByIdAsync(id);
        _ = user ?? throw new NotFoundException(_t["User is not exist"]);
        user.FcmToken.Remove(fcmToken);
        await _userRepository.UpdateAsync(user);
        return user.Id;
    }


    public async Task<Guid> Update(Guid id, UpdateUserRequest request)
    {
        var user = await _userRepository.GetByIdAsync(id);
        _ = user ?? throw new NotFoundException(_t["User is not exist"]);
        
        user.FullName = request.FullName ?? user.FullName;
        user.AvatarUrl = request.AvatarUrl ?? user.AvatarUrl;
        user.Phone = request.Phone ?? user.Phone;
        user.IdentityCard = request.IdentityCard ?? user.IdentityCard;
        user.Description = request.Biography ?? user.Description;
        user.Birthday = request.Birthday ?? user.Birthday;
        await _userRepository.UpdateAsync(user);
        return user.Id;
    }

    public async Task<Guid> UpdateFcmToken(Guid id, string fcmToken)
    {
        var user = await _userRepository.GetByIdAsync(id);
        _ = user ?? throw new NotFoundException(_t["User is not exist"]);
        user.FcmToken.Add(fcmToken);
        await _userRepository.UpdateAsync(user);
        return user.Id;
    }
}
