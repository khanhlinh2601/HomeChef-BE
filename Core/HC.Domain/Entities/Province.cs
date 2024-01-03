using HC.Domain.Common;
using HC.Domain.Common.Interfaces;

namespace HC.Domain.Entities;

public class Province : BaseEntity, IAggregateRoot
{
    public string Name { get; set; } = default!;
    public virtual ICollection<District> Districts { get; set; } = new List<District>();
}

