namespace HC.Domain.Dto.Requests;

public class CreateUserRequest
{
    public string? FcmToken { get; set; }
    public string Email { get; set; } = null!;
    public string? FullName { get; set; } = null!;
    public string? AvatarUrl { get; set; }
    public string Phone { get; set; } = null!;
    public DateTime? Birthday { get; set; }
    public Role Role { get; set; }

}

