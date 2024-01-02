using HC.Domain.Common;
using HC.Domain.Common.Interfaces;

namespace HC.Domain.Entities;

public class Feedback : BaseEntity, IAggregateRoot
{
    public Order Order { get; set; } = null!;
    public string Content { get; set; } = null!;
    public int Rating { get; set; } = 1;
}

