using HC.Domain.Dto;
using HC.Domain.Entities;

namespace HC.Application.Interfaces;

public interface ITransactionService
{
    Task<Transaction> Create(Order order);
    Task<TransactionResponse> GetById(Guid id);
    Task<IEnumerable<TransactionResponse>> GetByOrderId(Guid orderId);
}