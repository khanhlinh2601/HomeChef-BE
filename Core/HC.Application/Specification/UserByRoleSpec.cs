using Ardalis.Specification;

namespace HC.Application.Specification;

public class UserByRoleSpec : Specification<User>
{
    public UserByRoleSpec(Role role)
    {
        Query.Where(x => x.Role == role);
    }
}