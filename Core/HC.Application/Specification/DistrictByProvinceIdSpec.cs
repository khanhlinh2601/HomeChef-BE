using Ardalis.Specification;

namespace HC.Application.Specification;

public class DistrictByProvinceIdSpec : Specification<District>
{
    public DistrictByProvinceIdSpec(Guid provinceId)
    {
        Query.Where(x => x.ProvinceId == provinceId);
    }
}