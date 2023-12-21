using HC.Domain.Entities;

namespace HC.Application.Services;

public interface IVoucherOrderService
{
    Task<OrderVoucher> Create(Order order, Voucher voucher);
}