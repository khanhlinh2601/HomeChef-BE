using Ardalis.Specification;

namespace HC.Application.Specification
{
    public class OrderByCustomerIdSpec : Specification<Order>
    {
        public OrderByCustomerIdSpec(Guid customerId)
        {
            Query.Where(x => x.CreatedBy == customerId);
        }
    }
}