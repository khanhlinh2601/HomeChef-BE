using HC.Domain.Common.Enums;
using HC.Domain.Enums;

namespace HC.Domain.Dto.Responses;

public class OrderResponse
{
    public Guid Id { get; set; }
    public UserResponse Chef { get; set; } = default!;
    public OrderStatus Status { get; set; } = default!;
    public IEnumerable<TransactionResponse> Transaction { get; set; } = default!;
    public long TotalPrice { get; set; } = default!;
    public long Price { get; set; } = default!;
    public int Quantity { get; set; } = default!;
    public List<string> Dish { get; set; } = null!;
    public DishType DishType { get; set; } = default!;
    public TransactionMethod IntialTransactionMethod { get; set; } = default!;
    public string RejectReason { get; set; } = default!;

}