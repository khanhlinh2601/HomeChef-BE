using HC.Domain.Common;
using HC.Domain.Common.Interfaces;

namespace HC.Domain.Entities;

public class Transaction : BaseEntity, IAggregateRoot
{
    public double Amount { get; set; }
    public TransactionMethod TransactionMethod { get; set; }
    public TransactionType TransactionType { get; set; }
    public Common.Enums.TransactionStatus TransactionStatus { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = default!;
}