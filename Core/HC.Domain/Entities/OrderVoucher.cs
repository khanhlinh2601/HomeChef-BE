using HC.Domain.Common;

namespace HC.Domain.Entities;
public class OrderVoucher : BaseEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = default!;
    public Guid VoucherId { get; set; }
    public Voucher Voucher { get; set; } = default!;
    public long Amount { get; set; }
}
