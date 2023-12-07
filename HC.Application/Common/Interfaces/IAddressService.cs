using HC.Domain.Dto.Requests;
using HC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Application.Common.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<Province>> GetAllProvince();
        Task<IEnumerable<District>> GetAllDistrict();
        Task<Province> GetProvice(Guid id);
        Task<District> GetDistrict(Guid id);
        Task<bool> CreateCustomerAddress(CreateCustomerAddressRequest request);
        Task<bool> UpdateCustomerAddress(Guid id, CreateCustomerAddressRequest request);
        Task<bool> DeleteCustomerAddress(Guid id);
    }
}
