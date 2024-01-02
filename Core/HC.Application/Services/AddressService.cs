using HC.Application.Common.Persistence;
using HC.Application.Specification;
using Microsoft.Extensions.Localization;

namespace HC.Application.Services;

public class AddressService : IAddressService
{
    private readonly IRepository<Address> _addressRepository;
    private readonly IRepository<Province> _provinceRepository;
    private readonly IRepository<District> _districtRepository;

    private readonly IStringLocalizer _t;

    public AddressService(IRepository<Address> addressRepository,
                          IRepository<Province> provinceRepository,
                          IRepository<District> districtRepository,
                          IStringLocalizer<AddressService> t)
    {
        _addressRepository = addressRepository;
        _provinceRepository = provinceRepository;
        _districtRepository = districtRepository;
        _t = t;
    }

    public async Task<Guid> CreateAddress(CreateAddressRequest request)
    {
        var address = request.Adapt<Address>();
        await _addressRepository.AddAsync(address);
        return address.Id;
    }

    public async Task<Guid> DeleteAddress(Guid id)
    {
        var address = await _addressRepository.GetByIdAsync(id);
        _ = address ?? throw new NotFoundException(_t["Address is not exist"]);
        await _addressRepository.DeleteAsync(address);
        return address.Id;
    }

    public async Task<AddressResponse> GetAddressById(Guid id)
    {
        var address = await _addressRepository.GetByIdAsync(id);

        _ = address ?? throw new NotFoundException(_t["Address is not exist"]);
        return address.Adapt<AddressResponse>();
    }

    public async Task<IEnumerable<AddressResponse>> GetAddressesByCustomerId(Guid userId)
    {
        var address = await _addressRepository.ListAsync(new AddressByCustomerIdSpec(userId));
        return address.Adapt<IEnumerable<AddressResponse>>();
    }

    public async Task<IEnumerable<DistrictResponse>> GetDistricts()
    {
        var districts = await _districtRepository.ListAsync();
        return districts.Adapt<IEnumerable<DistrictResponse>>();
    }

    public async Task<IEnumerable<DistrictResponse>> GetDistrictsByProvinceId(Guid provinceId)
    {
        var districts = await _districtRepository.ListAsync(new DistrictByProvinceIdSpec(provinceId));
        return districts.Adapt<IEnumerable<DistrictResponse>>();
    }

    public async Task<IEnumerable<ProvinceResponse>> GetProvinces()
    {
        var provinces = await _provinceRepository.ListAsync();
        return provinces.Adapt<IEnumerable<ProvinceResponse>>();
    }

    public async Task<Guid> UpdateAddress(Guid id, UpdateAddressRequest request)
    {
        var address = await _addressRepository.GetByIdAsync(id);
        _ = address ?? throw new NotFoundException(_t["Address is not exist"]);
        address.DistrictId = request.DistrictId;
        address.HouseNumber = request.HouseNumber;
        address.Ward = request.Ward;
        address.Street = request.Street;
        await _addressRepository.UpdateAsync(address);
        return address.Id;
    }

}

