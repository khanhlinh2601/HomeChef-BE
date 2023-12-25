using HC.Application.Interfaces;
using HC.Domain.Dto.Requests;
using HC.Domain.Dto.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HC.API.Controllers;

public class AuthController : BaseApiController
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet("profile")]
    public async Task<ActionResult<UserResponse>> Get()
    {
        return User.GetUserId() is not { } userId
            ? Unauthorized()
            : Ok(await _authService.Get(Guid.Parse(userId)));
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
    {
        var result = await _authService.GetUserByFirebaseTokenAsync(loginRequest);
        return Ok(result);
    }

    [HttpDelete("logout")]
    public async Task<ActionResult<bool>> Logout(LogoutRequest logoutRequest)
    {
        return User.GetUserId() is not { } userId
            ? Unauthorized() : Ok(await _authService.Logout(Guid.Parse(userId), logoutRequest.FcmToken));
    }
}

