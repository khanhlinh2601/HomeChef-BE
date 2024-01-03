using HC.Application.Interfaces;
using HC.Domain.Dto.Requests;
using HC.Domain.Dto.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace HC.API.Controllers;

public class UserController : BaseApiController
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [AllowAnonymous]
    [OpenApiOperation("Get all users", "")]
    public async Task<ActionResult<IEnumerable<UserResponse>>> Get()
    {
        return Ok(await _userService.GetAll());
    }

    [HttpGet("{id}")]
    [OpenApiOperation("Get user by id", "")]
    public async Task<ActionResult<UserResponse>> GetById(Guid id)
    {
        return Ok(await _userService.GetById(id));
    }

    [HttpPost]
    [AllowAnonymous]
    [OpenApiOperation("Create user", "")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateUserRequest request)
    {
        return Ok(await _userService.Create(request));
    }
    
    [HttpPut("{id}")]
    [OpenApiOperation("Update user", "")]
    public async Task<ActionResult> Update(Guid id, [FromBody] UpdateUserRequest request)
    {
        return Ok(await _userService.Update(id, request));
    }
 
    [HttpDelete("{id}")]
    [OpenApiOperation("Delete user", "")]
    public async Task<ActionResult> Delete(Guid id)
    {
        return Ok(await _userService.Delete(id));
    }

    [HttpGet("chef")]
    [AllowAnonymous]
    [OpenApiOperation("Get all chefs", "")]
    public async Task<ActionResult<IEnumerable<UserResponse>>> GetChefs()
    {
        return Ok(await _userService.GetAllChef());
    }

    [HttpGet("customer")]
    [AllowAnonymous]
    [OpenApiOperation("Get all customers", "")]
    public async Task<ActionResult<IEnumerable<UserResponse>>> GetCustomers()
    {
        return Ok(await _userService.GetAllCustomer());
    }
}