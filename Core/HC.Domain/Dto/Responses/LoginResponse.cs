namespace HC.Domain.Dto.Responses;

public class LoginResponse
{
    public bool IsFirstTime { get; set; }
    public string Token { get; set; } = null!;
    public UserResponse User { get; set; } = null!;
}

