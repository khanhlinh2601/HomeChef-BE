using HC.Domain.Common;
using HC.Domain.Common.Enums;
using HC.Domain.Enums;

namespace HC.Domain.Entities;

public class Order : BaseEntity
{
    public Guid ChefId { get; set; }
    public OrderStatus Status { get; set; } = default!;
    public double TotalPrice { get; set; } = default!;
    public long Price { get; set; }
    public int Quantity { get; set; }
    public List<string> Dish { get; set; } = null!;
    public DishType DishType { get; set; }
    public TransactionMethod IntialTransactionMethod { get; set; } = default!;
    public List<OrderVoucher> OrderVouchers { get; set; } = new List<OrderVoucher>();
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    public string RejectReason { get; set; } = default!;
}

