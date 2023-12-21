using HC.Domain.Dto.Requests;
using HC.Domain.Dto.Responses;

namespace HC.Application.Interfaces;

public interface IAddressService
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