using HC.Domain.Common;
using HC.Domain.Common.Interfaces;

namespace HC.Domain.Entities;

public class Address : BaseEntity, IAggregateRoot
{
    public string HouseNumber { get; set; } = default!;
    public string Street { get; set; } = default!;
    public string Ward { get; set; } = default!;
    public string? Description { get; set; }
    public Guid DistrictId { get; set; }
    public District District { get; set; } = default!;
    public Guid CustomerId { get; set; }
}