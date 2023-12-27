namespace HC.Domain.Dto.Requests;
using FluentValidation;
public class CreateAddressRequest
{
    public string HouseNumber { get; set; } = null!;
    public string HouseType { get; set; } = null!;
    public string Ward { get; set; } = null!;
    public Guid DistrictId { get; set; }
    public Guid CustomerId { get; set; }
}

public class CreateAddressRequestValidator : AbstractValidator<CreateAddressRequest>
{
    public CreateAddressRequestValidator()
    {
        RuleFor(x => x.HouseNumber).NotEmpty();
        RuleFor(x => x.HouseType).NotEmpty();
        RuleFor(x => x.Ward).NotEmpty();
        RuleFor(x => x.DistrictId).NotEmpty();
        RuleFor(x => x.CustomerId).NotEmpty();
    }
}