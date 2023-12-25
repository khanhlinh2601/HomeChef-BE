namespace HC.Application.Interfaces;

public interface IAddressService : IScopedService
{
    Task<IEnumerable<ProvinceResponse>> GetProvinces();
    Task<IEnumerable<DistrictResponse>> GetDistricts();
    Task<IEnumerable<DistrictResponse>> GetDistrictsByProvinceId(Guid provinceId);
    Task<AddressResponse> GetAddressById(Guid id);
    Task<IEnumerable<AddressResponse>> GetAddressesByCustomerId(Guid userId);
    Task<Guid> CreateAddress(CreateAddressRequest request);
    Task<Guid> UpdateAddress(Guid id, UpdateAddressRequest request);
    Task<Guid> DeleteAddress(Guid id);
}