using HC.Application.Interfaces;
using HC.Domain.Dto.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HC.API.Controllers;

public class OrderController : BaseApiController
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        return Ok(await _orderService.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(Guid id)
    {
        return Ok(await _orderService.GetById(id));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateOrderRequest request)
    {
        return Ok(await _orderService.Create(request));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] UpdateOrderRequest request)
    {
        return Ok(await _orderService.Update(id, request));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        return Ok(await _orderService.Delete(id));
    }
    
}