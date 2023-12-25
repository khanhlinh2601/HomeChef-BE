namespace HC.Domain.Dto.Requests;

public class LoginRequest
{
    public string IdToken { get; set; } = null!;
    public string FcmToken { get; set; } = default!;
    public Role Role { get; set; } = Role.CUSTOMER;
}