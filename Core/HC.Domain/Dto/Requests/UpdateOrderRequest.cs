using HC.Domain.Common.Enums;
using HC.Domain.Enums;

namespace HC.Domain.Dto.Requests;

public class UpdateOrderRequest
{
    public Guid ChefId { get; set; }
    public OrderStatus Status { get; set; } = default!;
    public long TotalPrice { get; set; } = default!;
    public long Price { get; set; }
    public int Quantity { get; set; }
    public List<string> Dish { get; set; } = null!;
    public DishType DishType { get; set; }
    public TransactionMethod IntialTransactionMethod { get; set; } = default!;
    
    
}