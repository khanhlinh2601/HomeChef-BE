using HC.Domain.Common;
using HC.Domain.Common.Enums;

namespace HC.Domain.Entities;

public class OrderDetail : BaseEntity
{
    public int Quantity { get; set; }
    public List<string> Dish { get; set; } = null!;
    public DishType DishType { get; set; }
    public long Price { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = default!;
}

