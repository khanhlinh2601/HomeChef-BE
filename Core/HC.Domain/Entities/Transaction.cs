using System.Transactions;
using HC.Domain.Common;
using HC.Domain.Common.Enums;

namespace HC.Domain.Entities;

public class Transaction: BaseEntity{
    public double Amount { get; set; }
    public TransactionMethod TransactionMethod { get; set;}
    public TransactionType TransactionType { get; set;}
    public Common.Enums.TransactionStatus TransactionStatus { get; set;}
    public Order Order { get; set; } = default!;    
}