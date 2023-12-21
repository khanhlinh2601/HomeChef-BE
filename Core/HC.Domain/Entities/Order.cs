using HC.Domain.Common;
using HC.Domain.Common.Enums;
using HC.Domain.Enums;

namespace HC.Domain.Entities;

public class Order : BaseEntity
{
    public Guid ChefId { get; set; }
    public OrderStatus Status { get; set; } = default!;
    public double TotalPrice { get; set; } = default!;
    public TransactionMethod IntialTransactionMethod { get; set; } = default!;
    public List<OrderVoucher> OrderVouchers { get; set; } = new List<OrderVoucher>();
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    public string RejectReason { get; set; } = default!;
    public OrderDetail OrderDetail { get; set; } = default!;
}

