using Ardalis.Specification;

namespace HC.Application.Specification;

public class FeedbackByChefIdSpec : Specification<Feedback>
{
    public FeedbackByChefIdSpec(Guid chefId)
    {
        Query.Where(x => x.Order.ChefId == chefId);
    }
}