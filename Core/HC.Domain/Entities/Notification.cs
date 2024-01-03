using HC.Domain.Common;
using HC.Domain.Common.Interfaces;

namespace HC.Domain.Entities;

public class Notification : BaseEntity, IAggregateRoot
{
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public Guid ReceiverId { get; set; }
}

