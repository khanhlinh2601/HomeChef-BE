
using HC.Application.Common.Persistence;
using HC.Application.Specification;
using Microsoft.Extensions.Localization;

namespace HC.Application.Services;

public class TransactionService : ITransactionService
{
    private readonly IRepository<Transaction> _transactionRepository;
    private readonly IStringLocalizer<TransactionService> _t;
    
    public TransactionService(IRepository<Transaction> transactionRepository, IStringLocalizer<TransactionService> t)
    {
        _transactionRepository = transactionRepository;
        _t = t;
    }

    // private readonly IGenericRepository<Transaction> _transactionRepository;

    // public TransactionService(IGenericRepository<Transaction> transactionRepository)
    // {
    //     _transactionRepository = transactionRepository;
    // }

    // public async Task<Transaction> Create(Order order)
    // {
    //     var entity = new Transaction
    //     {
    //         OrderId = order.Id,
    //         Amount = order.TotalPrice,
    //         TransactionStatus = TransactionStatus.PENDING,
    //         TransactionType = TransactionType.PURCHASE,
    //         TransactionMethod = order.IntialTransactionMethod
    //     };
    //     await _transactionRepository.CreateAsync(entity);
    //     return entity;
    // }
    // public async Task<TransactionResponse> GetById(Guid id)
    // {
    //     var entity = await _transactionRepository.GetByIdAsync(id);
    //     return entity.Adapt<TransactionResponse>();
    // }
    // public async Task<IEnumerable<TransactionResponse>> GetByOrderId(Guid orderId)
    // {
    //     var entities = await _transactionRepository.WhereAsync(x => x.OrderId == orderId);
    //     return entities.Adapt<IEnumerable<TransactionResponse>>();
    // }
    public async Task<Transaction> Create(Order order)
    {
        var entity = new Transaction
        {
            OrderId = order.Id,
            Amount = order.TotalPrice,
            TransactionStatus = TransactionStatus.PENDING,
            TransactionType = TransactionType.PURCHASE,
            TransactionMethod = order.IntialTransactionMethod
        };

        await _transactionRepository.AddAsync(entity);
        return entity;
    }

    public async Task<TransactionResponse> GetById(Guid id)
    {
        var entity = await _transactionRepository.GetByIdAsync(id);
        _ = entity ?? throw new NotFoundException(_t["Transaction not found"]);
        return entity.Adapt<TransactionResponse>();

    }

    public async Task<IEnumerable<TransactionResponse>> GetByOrderId(Guid orderId)
    {
        var entities = await _transactionRepository.ListAsync(new TransactionByOrderIdSpec(orderId));
        return entities.Adapt<IEnumerable<TransactionResponse>>();
    }
}