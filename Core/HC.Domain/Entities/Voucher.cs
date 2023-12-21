using HC.Domain.Common;
using HC.Domain.Common.Enums;

namespace HC.Domain.Entities;

public class Voucher : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public long Value { get; set; } = 0;
    public int OriginalQuantity { get; set; } = 0;
    public int Quantity { get; set; } = 0;
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = default!;
    public bool IsActive { get; set; } = true;
    public VoucherDiscountType DiscountType { get; set; }
}
