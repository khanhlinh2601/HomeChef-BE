using Ardalis.Specification;

namespace HC.Application.Specification
{
    public class UserByIdSpec : Specification<User>
    {
        public UserByIdSpec(Guid id)
        {
            Query.Where(x => x.Id == id);
        }
    }
}