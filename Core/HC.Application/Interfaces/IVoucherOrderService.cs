namespace HC.Application.Services;

public interface IVoucherOrderService : IScopedService
{
    Task<OrderVoucher> Create(Order order, Voucher voucher);
}