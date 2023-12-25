using HC.Application.Interfaces;
using HC.Domain.Dto.Requests;
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
    [OpenApiOperation("Get all users", "")]
    public async Task<ActionResult> Get()
    {
        return Ok(await _userService.GetAll());
    }

    [HttpGet("{id}")]
    [OpenApiOperation("Get user by id", "")]
    public async Task<ActionResult> GetById(Guid id)
    {
        return Ok(await _userService.GetById(id));
    }

    [HttpPost]
    [OpenApiOperation("Create user", "")]
    public async Task<ActionResult> Create([FromBody] CreateUserRequest request)
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
}