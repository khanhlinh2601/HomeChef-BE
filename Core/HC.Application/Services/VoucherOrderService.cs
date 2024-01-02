using HC.Application.Common.Persistence;
using Microsoft.Extensions.Localization;

namespace HC.Application.Services;

public class VoucherOrderService : IVoucherOrderService
{
    private readonly IRepository<OrderVoucher> _orderVoucherRepository;
    private readonly IStringLocalizer<VoucherOrderService> _t;

    public VoucherOrderService(IRepository<OrderVoucher> orderVoucherRepository, IStringLocalizer<VoucherOrderService> t)
    {
        _orderVoucherRepository = orderVoucherRepository;
        _t = t;
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
        await _orderVoucherRepository.AddAsync(entity);
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