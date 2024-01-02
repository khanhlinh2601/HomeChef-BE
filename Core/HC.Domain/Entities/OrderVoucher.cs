using HC.Domain.Common;
using HC.Domain.Common.Interfaces;

namespace HC.Domain.Entities;
public class OrderVoucher : BaseEntity, IAggregateRoot
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = default!;
    public Guid VoucherId { get; set; }
    public Voucher Voucher { get; set; } = default!;
    public long Amount { get; set; }
}
