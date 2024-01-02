using Ardalis.Specification;

namespace HC.Application.Specification
{
    public class OrderByChefIdSpec : Specification<Order>
    {
        public OrderByChefIdSpec(Guid chefId)
        {
            Query.Where(x => x.ChefId == chefId);
        }
    }
}