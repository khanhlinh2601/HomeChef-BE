
namespace HC.Domain.Dto.Responses;

public class VoucherResponse
{
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public long Value { get; set; } = 0;
    public int Quantity { get; set; } = 0;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public VoucherDiscountType DiscountType { get; set; }
    public bool IsActive { get; set; }
}