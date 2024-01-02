using Ardalis.Specification;

namespace HC.Application.Specification;

public class VoucherByListId : Specification<Voucher>
{
    public VoucherByListId(List<Guid> ids)
    {
        Query.Where(x => ids.Contains(x.Id) 
                && x.IsActive
                && x.StartDate <= DateTime.Now
                && x.EndDate >= DateTime.Now
                && x.Quantity > 0
        );
    }
}