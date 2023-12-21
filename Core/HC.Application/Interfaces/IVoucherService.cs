using HC.Domain.Dto.Requests;
using HC.Domain.Dto.Responses;
using HC.Domain.Entities;

namespace HC.Application.Interfaces;

public interface IVoucherService
{
    Task<Guid> Create(CreateVoucherRequest request);
    Task<VoucherResponse> GetById(Guid id);
    Task<IEnumerable<VoucherResponse>> GetAll();
    Task<Guid> Update(Guid id, CreateVoucherRequest request);
    Task<Guid> Delete(Guid id);
    Task<IEnumerable<Voucher>> GetVoucherByListId(List<Guid> ids);
}