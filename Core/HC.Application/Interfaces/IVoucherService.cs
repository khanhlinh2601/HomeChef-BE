namespace HC.Application.Interfaces;

public interface IVoucherService : IScopedService
{
    Task<Guid> Create(CreateVoucherRequest request);
    Task<VoucherResponse> GetById(Guid id);
    Task<IEnumerable<VoucherResponse>> GetAll();
    Task<Guid> Update(Guid id, CreateVoucherRequest request);
    Task<Guid> Delete(Guid id);
    Task<IEnumerable<Voucher>> GetVoucherByListId(List<Guid> ids);
}