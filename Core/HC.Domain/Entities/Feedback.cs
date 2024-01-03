using HC.Domain.Common;
using HC.Domain.Common.Interfaces;

namespace HC.Domain.Entities;

public class Feedback : BaseEntity, IAggregateRoot
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public string? Content { get; set; }
    public int Rating { get; set; } = 1;
}

