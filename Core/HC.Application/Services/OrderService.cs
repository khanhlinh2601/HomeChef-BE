using HC.Application.Common.Interfaces;
using HC.Application.Interfaces;
using HC.Domain.Entities;
using Mapster;

namespace HC.Application.Services;

public class OrderService
{
    private readonly IGenericRepository<Order> _orderRepository;
    private readonly IVoucherOrderService _voucherOrderService;
    private readonly IVoucherService _voucherService;

    public OrderService(IGenericRepository<Order> orderRepository, IVoucherOrderService voucherOrderService, IVoucherService voucherService)
    {
        _orderRepository = orderRepository;
        _voucherOrderService = voucherOrderService;
        _voucherService = voucherService;
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



        await _orderRepository.CreateAsync(entity);
        return entity.Id;
    }



}