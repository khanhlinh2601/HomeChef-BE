namespace HC.Application.Services;

public class AddressService : IAddressService
{
    private readonly IGenericRepository<Province> _provinceRepository;
    private readonly IGenericRepository<District> _districtRepository;
    private readonly IGenericRepository<Address> _addressRepository;

    public AddressService(IGenericRepository<Province> provinceRepository,
                          IGenericRepository<District> districtRepository,
                        IGenericRepository<Address> addressRepository)
    {
        _provinceRepository = provinceRepository;
        _districtRepository = districtRepository;
        _addressRepository = addressRepository;
    }

    public async Task<IEnumerable<ProvinceResponse>> GetProvinces()
    {
        var provinces = await _provinceRepository.GetAllAsync();
        return provinces.Adapt<IEnumerable<ProvinceResponse>>();
    }

    public async Task<IEnumerable<DistrictResponse>> GetDistricts()
    {
        var districts = await _districtRepository.GetAllAsync();
        return districts.Adapt<IEnumerable<DistrictResponse>>();
    }
    
    public async Task<IEnumerable<DistrictResponse>> GetDistrictsByProvinceId(Guid provinceId)
    {
        var districts = await _districtRepository.WhereAsync(x => x.ProvinceId == provinceId);
        return districts.Adapt<IEnumerable<DistrictResponse>>();
    }
    public async Task<AddressResponse> GetAddressById(Guid id)
    {
        var address = await _addressRepository.GetByIdAsync(id);
        return address.Adapt<AddressResponse>();
    }
    public async Task<IEnumerable<AddressResponse>> GetAddressesByCustomerId(Guid userId)
    {
        var addresses = await _addressRepository.WhereAsync(x => x.CustomerId == userId);
        return addresses.Adapt<IEnumerable<AddressResponse>>();
    }

    public async Task<Guid> CreateAddress(CreateAddressRequest request)
    {
        var address = request.Adapt<Address>();
        await _addressRepository.CreateAsync(address);
        return address.Id;
    }
    public async Task<Guid> UpdateAddress(Guid id, UpdateAddressRequest request)
    {
        var address = await _addressRepository.GetByIdAsync(id);
        if (address is null)
        {
            throw new BadRequestException("Address is not exist");
        }
        address = request.Adapt(address);
        await _addressRepository.UpdateAsync(address);
        return address.Id;
    }
    public async Task<Guid> DeleteAddress(Guid id)
    {
        var address = await _addressRepository.GetByIdAsync(id);
        if (address is null)
        {
            throw new BadRequestException("Address is not exist");
        }
        await _addressRepository.DeleteAsync(id);
        return address.Id;
    }
}

