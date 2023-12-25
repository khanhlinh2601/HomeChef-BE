namespace HC.Application.Services;

public class VoucherService : IVoucherService
{
    private readonly IGenericRepository<Voucher> _voucherRepository;

    public VoucherService(IGenericRepository<Voucher> voucherRepository)
    {
        _voucherRepository = voucherRepository;
    }

    public async Task<Guid> Create(CreateVoucherRequest request)
    {
        var entity = request.Adapt<Voucher>();
        await _voucherRepository.CreateAsync(entity);
        return entity.Id;
    }

    public async Task<VoucherResponse> GetById(Guid id)
    {
        var entity = await _voucherRepository.GetByIdAsync(id);
        return entity.Adapt<VoucherResponse>();
    }
    public async Task<IEnumerable<VoucherResponse>> GetAll()
    {
        var entities = await _voucherRepository.GetAllAsync();
        return entities.Adapt<IEnumerable<VoucherResponse>>();
    }

    public async Task<Guid> Update(Guid id, CreateVoucherRequest request)
    {
        var entity = await _voucherRepository.GetByIdAsync(id);
        if (entity == null)
        {
            throw new BadRequestException("Voucher not found");
        }
        entity = request.Adapt<Voucher>();
        await _voucherRepository.UpdateAsync(entity);
        return entity.Id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        var entity = await _voucherRepository.GetByIdAsync(id);
        if (entity == null)
        {
            throw new BadRequestException("Voucher not found");
        }
        await _voucherRepository.DeleteAsync(id);
        return entity.Id;
    }

    public async Task<IEnumerable<Voucher>> GetVoucherByListId(List<Guid> ids)
    {
        var entities = new List<Voucher>();
        foreach (var id in ids)
        {
            var entity = await _voucherRepository.GetOneByConditionAsync(

                expression: x => x.Id == id && x.IsActive && x.Quantity > 0
                            && x.StartDate <= DateTime.Now && x.EndDate >= DateTime.Now
            );
            if (entity == null)
            {
                throw new BadRequestException("Voucher not found");
            }
            entities.Add(entity);
        }
        return entities;
    }
}