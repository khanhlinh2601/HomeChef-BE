using Ardalis.Specification;

namespace HC.Application.Specification
{
    public class UserByEmailPhoneSpec : Specification<User>
    {
        public UserByEmailPhoneSpec(string? email, string? phone)
        {
            Query.Where(x => x.Email == email || x.Phone == phone);
        }
    }
}