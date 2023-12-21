using HC.Domain.Common;

namespace HC.Domain.Entities;
public class OrderVoucher : BaseEntity
{
    public Order Order { get; set; } = default!;
    public Voucher Voucher { get; set; } = default!;
    public long Amount { get; set; }
}
