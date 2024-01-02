using Ardalis.Specification;

namespace HC.Application.Specification;

public class TransactionByOrderIdSpec : Specification<Transaction>
{
    public TransactionByOrderIdSpec(Guid orderId)
    {
        Query.Where(x => x.OrderId == orderId);
    }
}