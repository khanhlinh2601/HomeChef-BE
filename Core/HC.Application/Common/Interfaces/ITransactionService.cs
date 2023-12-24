
using HC.Domain.Entities;

namespace HC.Application.Interfaces;

public interface ITransactionService
{
    Task<Transaction> Create(Order order);
}