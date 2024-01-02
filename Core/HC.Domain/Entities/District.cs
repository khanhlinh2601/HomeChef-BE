using HC.Domain.Common;
using HC.Domain.Common.Interfaces;

namespace HC.Domain.Entities;

public class District : BaseEntity, IAggregateRoot
{
    public string Name { get; set; } = default!;
    public Guid ProvinceId { get; set; }
    public Province Province { get; set; } = default!;
    public List<User> Chefs { get; set; } = default!;
}

