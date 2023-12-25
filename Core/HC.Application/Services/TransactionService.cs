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
        var entity = new Transaction
        {
            OrderId = order.Id,
            Amount = order.TotalPrice,
            TransactionStatus = TransactionStatus.PENDING,
            TransactionType = TransactionType.PURCHASE,
            TransactionMethod = order.IntialTransactionMethod
        };
        await _transactionRepository.CreateAsync(entity);
        return entity;
    }
    public async Task<TransactionResponse> GetById(Guid id)
    {
        var entity = await _transactionRepository.GetByIdAsync(id);
        return entity.Adapt<TransactionResponse>();
    }
    public async Task<IEnumerable<TransactionResponse>> GetByOrderId(Guid orderId)
    {
        var entities = await _transactionRepository.WhereAsync(x => x.OrderId == orderId);
        return entities.Adapt<IEnumerable<TransactionResponse>>();
    }


}