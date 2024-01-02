using HC.Application.Common.Persistence;
using HC.Application.Specification;
using Microsoft.Extensions.Localization;

namespace HC.Application.Services;

public class VoucherService : IVoucherService
{
    private readonly IRepository<Voucher> _voucherRepository;
    private readonly IStringLocalizer _t;

    public VoucherService(IRepository<Voucher> voucherRepository, IStringLocalizer<VoucherService> t)
    {
        _voucherRepository = voucherRepository;
        _t = t;
    }

    public async Task<Guid> Create(CreateVoucherRequest request)
    {
        var entity = request.Adapt<Voucher>();
        await _voucherRepository.AddAsync(entity);
        return entity.Id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        var entity = await _voucherRepository.GetByIdAsync(id);

        _ = entity ?? throw new NotFoundException(_t["Voucher is not exist"]);
        
        await _voucherRepository.DeleteAsync(entity);
        return entity.Id;
    }

    public async Task<IEnumerable<VoucherResponse>> GetAll()
    {
        var entities = await _voucherRepository.ListAsync();
        return entities.Adapt<IEnumerable<VoucherResponse>>();
    }

    public async Task<VoucherResponse> GetById(Guid id)
    {
        var entity = await _voucherRepository.GetByIdAsync(id);
        _ = entity ?? throw new NotFoundException(_t["Voucher is not exist"]);
        return entity.Adapt<VoucherResponse>();
        
    }

    public async Task<IEnumerable<Voucher>> GetVoucherByListId(List<Guid> ids)
    {
        var entities = new List<Voucher>();
        foreach (var id in ids)
        {
            var entity = await _voucherRepository.FirstOrDefaultAsync(new VoucherByListId(ids));
            _ = entity ?? throw new NotFoundException(_t["Voucher is not exist"]);
            entities.Add(entity);
        }
        return entities;
    }

    public async Task<Guid> Update(Guid id, CreateVoucherRequest request)
    {
        var entity = await _voucherRepository.GetByIdAsync(id);
        _ = entity ?? throw new NotFoundException(_t["Voucher is not exist"]);
        entity = request.Adapt<Voucher>();
        await _voucherRepository.UpdateAsync(entity);
        return entity.Id;
    }
}