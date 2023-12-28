using HC.Application.Interfaces;
using HC.Domain.Dto.Requests;
using HC.Domain.Dto.Responses;
using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<OrderResponse>>> Get()
    {
        return Ok(await _orderService.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderResponse>> GetById(Guid id)
    {
        return Ok(await _orderService.GetById(id));
    }

    [HttpPost]
    public async Task<ActionResult<OrderResponse>> Create([FromBody] CreateOrderRequest request)
    {
        return Ok(await _orderService.Create(request));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] UpdateOrderRequest request)
    {
        return Ok(await _orderService.Update(id, request));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Guid>> Delete(Guid id)
    {
        return Ok(await _orderService.Delete(id));
    }
    
}