namespace HC.Application.Interfaces;

public interface ITransactionService : IScopedService
{
    Task<Transaction> Create(Order order);
    Task<TransactionResponse> GetById(Guid id);
    Task<IEnumerable<TransactionResponse>> GetByOrderId(Guid orderId);
}