using HC.Domain.Common.Enums;

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