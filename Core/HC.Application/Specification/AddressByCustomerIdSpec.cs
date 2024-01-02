using Ardalis.Specification;

namespace HC.Application.Specification;

public class AddressByCustomerIdSpec : Specification<Address>
{
    public AddressByCustomerIdSpec(Guid customerId)
    {
        Query.Where(x => x.CustomerId == customerId);
    }
}