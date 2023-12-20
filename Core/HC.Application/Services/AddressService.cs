using HC.Application.Common.Exceptions;
using HC.Application.Common.Interfaces;
using HC.Domain.Dto.Requests;
using HC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Province>> GetAllProvince()
        {
            var provinces = await _unitOfWork.Province.GetAllAsync();
            return provinces;
        }

        public async Task<IEnumerable<District>> GetAllDistrict()
        {
            var districts = await _unitOfWork.District.GetAllAsync();
            return districts;
        }

        public async Task<Province> GetProvice(Guid id)
        {
            var province = await _unitOfWork.Province.GetOneByConditionAsync(
                
                
                expression: x => x.Id == id,
                               includeProperties: new System.Linq.Expressions.Expression<Func<Province, object>>[] { x => x.Districts }
                                              );
            return province;
        }

        public async Task<District> GetDistrict(Guid id)
        {
            var district = await _unitOfWork.District.GetOneByConditionAsync(
                               expression: x => x.Id == id,
                                              includeProperties: new System.Linq.Expressions.Expression<Func<District, object>>[] { x => x.Province }
                                                             );
            return district;
        }

        public async Task<bool> CreateCustomerAddress (CreateCustomerAddressRequest request){
            
            var result = await _unitOfWork.CustomerAddress.CreateAsync(new CustomerAddress()
            {
                HouseNumber = request.HouseNumber,
                HouseType = request.HouseType,
                Ward = request.Ward,
                DistrictId = request.DistrictId,
                UserId = request.UserId
            });

            await _unitOfWork.SaveChangesAsync();
            return result > 0;

        }

        public async Task<bool> UpdateCustomerAddress (Guid id, CreateCustomerAddressRequest request)
        {
            var customerAddress = await _unitOfWork.CustomerAddress.GetByIdAsync(id);
            if (customerAddress is null)
            {
                throw new BadRequestException("Customer Address is not exist");
            }
            customerAddress.HouseNumber = request.HouseNumber;
            customerAddress.HouseType = request.HouseType;
            customerAddress.Ward = request.Ward;
            customerAddress.DistrictId = request.DistrictId;
            customerAddress.UserId = request.UserId;

            var result = await _unitOfWork.CustomerAddress.UpdateAsync(customerAddress);
            await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteCustomerAddress(Guid id)
        {
            var customerAddress = await _unitOfWork.CustomerAddress.GetByIdAsync(id);
            if (customerAddress is null)
            {
                throw new BadRequestException("Customer Address is not exist");
            }
            var result = await _unitOfWork.CustomerAddress.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return result != null;
        }
    }
}
