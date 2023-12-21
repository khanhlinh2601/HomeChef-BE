using HC.Application.Common.Interfaces;
using HC.Domain.Entities;

namespace HC.Application.Services;

public class TransactionService
{
    private readonly IGenericRepository<Transaction> _transactionRepository;

    public TransactionService(IGenericRepository<Transaction> transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }



}