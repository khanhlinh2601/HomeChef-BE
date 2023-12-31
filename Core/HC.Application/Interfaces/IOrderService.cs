namespace HC.Application.Interfaces;

public interface IOrderService : IScopedService
{
    Task<Guid> Create(CreateOrderRequest request);
    Task<OrderResponse> GetById (Guid id);
    Task<Order> GetOrderById (Guid id);
    Task<IEnumerable<OrderResponse>> GetAll();
    Task<Guid> Delete(Guid id);
    Task<Guid> Update(Guid id, UpdateOrderRequest request);
    Task<IEnumerable<OrderResponse>> GetOrderByCustomerId(Guid customerId);
    Task<IEnumerable<OrderResponse>> GetOrderByChefId(Guid chefId);
}