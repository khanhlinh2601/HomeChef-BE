using HC.Domain.Common;

namespace HC.Domain.Entities;

public class District : BaseEntity
{
    public string Name { get; set; } = default!;
    public Guid ProvinceId { get; set; }
    public Province Province { get; set; } = default!;
    public List<User> Chefs { get; set; } = default!;
}

