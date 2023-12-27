using HC.Domain.Common.Enums;
using HC.Domain.Enums;

namespace HC.Domain.Dto.Requests;

public class CreateOrderRequest
{
    public Guid CustomerId { get; set; }
    public Guid ChefId  { get; set; }
    public Guid AddressId { get; set; }
    public DishType DishType { get; set; } = default!;
    public string? Note { get; set; }
    public int Quantity { get; set; } = default!;
    public long Price { get; set; } = default!;
    public TransactionMethod TransactionMethod { get; set; } = default!;
    public DateTime CookedTime { get; set; } = default!;
    public int CookedHour { get; set; } = default!;
    public List<Guid> VoucherIds { get; set; } = default!;  
}