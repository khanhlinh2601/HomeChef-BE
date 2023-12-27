using FluentValidation;

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

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.FullName).NotEmpty();
        RuleFor(x => x.Phone).Matches(@"^(0|\+84)[3|5|7|8|9][0-9]{8}$");
        RuleFor(x => x.Role).IsInEnum();
    }
}

