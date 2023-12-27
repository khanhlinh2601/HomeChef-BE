using HC.Application.Interfaces;
using HC.Domain.Dto.Requests;
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
    public async Task<ActionResult> GetProvinces()
    {
        return Ok(await _addressService.GetProvinces());
    }

    [HttpGet("districts")]
    public async Task<ActionResult> GetDistricts()
    {
        return Ok(await _addressService.GetDistricts());
    }

    [HttpGet("districts/{provinceId}")]
    public async Task<ActionResult> GetDistrictsByProvinceId(Guid provinceId)
    {
        return Ok(await _addressService.GetDistrictsByProvinceId(provinceId));
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetAddressById(Guid id)
    {
        return Ok(await _addressService.GetAddressById(id));
    }
    [HttpGet("customers/{userId}")]
    public async Task<ActionResult> GetAddressesByCustomerId(Guid userId)
    {
        return Ok(await _addressService.GetAddressesByCustomerId(userId));
    }
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateAddressRequest request)
    {
        return Ok(await _addressService.CreateAddress(request));
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] UpdateAddressRequest request)
    {
        return Ok(await _addressService.UpdateAddress(id, request));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        return Ok(await _addressService.DeleteAddress(id));
    }
}