using HC.Application.Common.Interfaces;
using HC.Application.Interfaces;
using HC.Domain.Common.Enums;
using HC.Domain.Entities;

namespace HC.Application.Services;

public class TransactionService : ITransactionService
{
    private readonly IGenericRepository<Transaction> _transactionRepository;

    public TransactionService(IGenericRepository<Transaction> transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<Transaction> Create(Order order)
    {
        Transaction entity = new()
        {
            Amount = order.TotalPrice,
            TransactionMethod = order.IntialTransactionMethod,
            TransactionType = TransactionType.PURCHASE,
            TransactionStatus = TransactionStatus.PENDING,
            Order = order
        };

        await _transactionRepository.CreateAsync(entity);
        return entity;
    }






}