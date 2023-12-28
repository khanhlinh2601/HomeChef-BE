using HC.Application.Interfaces;
using HC.Domain.Dto.Requests;
using HC.Domain.Dto.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HC.API.Controllers;

public class AddressController : BaseApiController
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet("provinces")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ProvinceResponse>>> GetProvinces()
    {
        return Ok(await _addressService.GetProvinces());
    }

    [HttpGet("districts")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<DistrictResponse>>> GetDistricts()
    {
        return Ok(await _addressService.GetDistricts());
    }

    [HttpGet("districts/{provinceId}")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<DistrictResponse>>> GetDistrictsByProvinceId(Guid provinceId)
    {
        return Ok(await _addressService.GetDistrictsByProvinceId(provinceId));
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<AddressResponse>> GetAddressById(Guid id)
    {
        return Ok(await _addressService.GetAddressById(id));
    }
    [HttpGet("customers/{userId}")]
    public async Task<ActionResult<IEnumerable<AddressResponse>>> GetAddressesByCustomerId(Guid userId)
    {
        return Ok(await _addressService.GetAddressesByCustomerId(userId));
    }
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateAddressRequest request)
    {
        return Ok(await _addressService.CreateAddress(request));
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] UpdateAddressRequest request)
    {
        return Ok(await _addressService.UpdateAddress(id, request));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Guid>> Delete(Guid id)
    {
        return Ok(await _addressService.DeleteAddress(id));
    }
}