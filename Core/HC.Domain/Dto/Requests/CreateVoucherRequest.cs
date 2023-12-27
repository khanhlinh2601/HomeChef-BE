using FluentValidation;

namespace HC.Domain.Dto.Requests;

public class CreateVoucherRequest 
{
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public long Value { get; set; } = 0;
    public int Quantity { get; set; } = 0;
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; }
    public VoucherDiscountType DiscountType { get; set; } = VoucherDiscountType.PERCENT;
    public bool IsActive { get; set; }
}

public class CreateVoucherRequestValidator : AbstractValidator<CreateVoucherRequest>
{
    public CreateVoucherRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Code).NotEmpty();
        RuleFor(x => x.Value).NotEmpty();
        RuleFor(x => x.Quantity).NotEmpty();
        RuleFor(x => x.StartDate).NotEmpty();
        RuleFor(x => x.EndDate).NotEmpty();
        RuleFor(x => x.DiscountType).IsInEnum();
        RuleFor(x => x.IsActive).NotEmpty();
    }
}   