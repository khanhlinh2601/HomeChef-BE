using HC.Application.Common.Persistence;
using HC.Application.Specification;

namespace HC.Application.Services;

public class OrderService : IOrderService
{
    private readonly IRepository<Order> _orderRepository;
    private readonly IVoucherOrderService _voucherOrderService;
    private readonly IVoucherService _voucherService;
    private readonly ITransactionService _transactionService;
    private readonly INotificationService _notificationService;
    private readonly ICurrentUser _currentUser;
    private readonly IUserService _userService;

    public OrderService(IRepository<Order> orderRepository, IVoucherOrderService voucherOrderService, IVoucherService voucherService, ITransactionService transactionService, INotificationService notificationService, ICurrentUser currentUser, IUserService userService)
    {
        _orderRepository = orderRepository;
        _voucherOrderService = voucherOrderService;
        _voucherService = voucherService;
        _transactionService = transactionService;
        _notificationService = notificationService;
        _currentUser = currentUser;
        _userService = userService;
    }

    public async Task<Guid> Create(CreateOrderRequest request)
    {
        var entity = request.Adapt<Order>();
        entity.TotalPrice = entity.Price;

        var vouchers = await _voucherService.GetVoucherByListId(request.VoucherIds);
        foreach (var voucher in vouchers)
        {
            var orderVoucher = await _voucherOrderService.Create(entity, voucher);
            entity.OrderVouchers.Add(orderVoucher);
            entity.TotalPrice -= orderVoucher.Amount;
        }

        var transaction = await _transactionService.Create(entity);
        entity.Transactions.Add(transaction);
        await _orderRepository.AddAsync(entity);

        await _notificationService.CreateAsync(new Notification
        {
            Title = "New order",
            Description = $"You have a new order ",
            ReceiverId = _currentUser.GetUserId(),
        });
        return entity.Id;
    }
    public async Task<OrderResponse> GetById(Guid id)
    {
        var order = await GetOrderById(id);
        OrderResponse result = order.Adapt<OrderResponse>();
        result.Chef = await _userService.GetById(order.ChefId);
        result.Transaction = await _transactionService.GetByOrderId(order.Id);
        return result;
    }

    public async Task<Order> GetOrderById(Guid id)
    {
        var entity = await _orderRepository.GetByIdAsync(id);
        if (entity == null)
        {
            throw new NotFoundException("Order not found");
        }
        return entity;
    }

    public async Task<IEnumerable<OrderResponse>> GetAll()
    {
        var entities = await _orderRepository.ListAsync();

        return entities.Adapt<IEnumerable<OrderResponse>>();
    }
    public async Task<IEnumerable<OrderResponse>> GetOrderByCustomerId(Guid customerId)
    {
        var entities = await _orderRepository.ListAsync(new OrderByCustomerIdSpec(customerId));
        return entities.Adapt<IEnumerable<OrderResponse>>();
    }

    public async Task<IEnumerable<OrderResponse>> GetOrderByChefId(Guid chefId)
    {
        var entities = await _orderRepository.ListAsync(new OrderByChefIdSpec(chefId));
        return entities.Adapt<IEnumerable<OrderResponse>>();
    }
    public async Task<Guid> Delete(Guid id)
    {
        var entity = await GetOrderById(id);
        await _orderRepository.DeleteAsync(entity);
        return id;
    }
    public async Task<Guid> Update(Guid id, UpdateOrderRequest request)
    {
        var entity = await GetOrderById(id);
        await _orderRepository.UpdateAsync(entity);
        return id;
    }
}
