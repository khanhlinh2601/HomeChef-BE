using HC.Application.Common.Interfaces;
using HC.Domain.Common.Enums;
using HC.Domain.Entities;

namespace HC.Application.Services;

public class VoucherOrderService : IVoucherOrderService
{

    private readonly IGenericRepository<OrderVoucher> _orderVoucherRepository;

    public VoucherOrderService(IGenericRepository<OrderVoucher> orderVoucherRepository)
    {
        _orderVoucherRepository = orderVoucherRepository;
    }

    public async Task<OrderVoucher> Create(Order order, Voucher voucher)
    {
        var discountAmount = CalculateDiscountAmount(order, voucher);
        var entity = new OrderVoucher
        {
            OrderId = order.Id,
            VoucherId = voucher.Id,
            Amount = discountAmount
        };
        await _orderVoucherRepository.CreateAsync(entity);
        return entity;
    }
    private long CalculateDiscountAmount(Order order, Voucher voucher)
    {
        var discountAmount = 0L;
        switch (voucher.DiscountType)
        {
            case VoucherDiscountType.PERCENT:
                discountAmount = order.Price * voucher.Value / 100;
                break;
            case VoucherDiscountType.CASH:
                discountAmount = voucher.Value;
                break;
        }

        return discountAmount;
    }
}