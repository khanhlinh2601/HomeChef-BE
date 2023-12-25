
namespace HC.Domain.Dto.Responses;

public class TransactionResponse
{
    public Guid Id { get; set; }
    public long Amount { get; set; }
    public TransactionMethod TransactionMethod { get; set; }
    public TransactionType TransactionType { get; set; }
    public TransactionStatus TransactionStatus { get; set; }
}