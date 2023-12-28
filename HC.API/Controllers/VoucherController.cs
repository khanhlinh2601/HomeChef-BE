using HC.Application.Interfaces;
using HC.Domain.Dto.Requests;
using HC.Domain.Dto.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HC.API.Controllers;

public class VoucherController : BaseApiController
{
    private readonly IVoucherService _voucherService;

    public VoucherController(IVoucherService voucherService)
    {
        _voucherService = voucherService;
    }

    [HttpGet]
    public async Task<ActionResult<VoucherResponse>> Get()
    {
        return Ok(await _voucherService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VoucherResponse>> GetById(Guid id)
    {
        return Ok(await _voucherService.GetById(id));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateVoucherRequest request)
    {
        return Ok(await _voucherService.Create(request));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] CreateVoucherRequest request)
    {
        return Ok(await _voucherService.Update(id, request));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Guid>> Delete(Guid id)
    {
        return Ok(await _voucherService.Delete(id));
    }

}