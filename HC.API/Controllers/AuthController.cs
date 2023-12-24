// using HC.Application.Common.Interfaces;
// using HC.Application.Interfaces;
// using HC.Domain.Common.Models;
// using HC.Domain.Dto.Requests;
// using HC.Domain.Dto.Responses;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.IdentityModel.Tokens;
// using System.Security.Claims;

// namespace HC.API.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class AuthController : ControllerBase
//     {
//         private readonly IAuthService _authService;
//         public AuthController(IAuthService authService)
//         {
//             _authService = authService;
//         }

//         [HttpGet]
//         public async Task<Response<UserResponse>> Get()
//         {
//             string rawUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
//             if (rawUserId.IsNullOrEmpty())
//             {
//                 return Response<UserResponse>("Invalid Token");
//             }
//             Guid userId = Guid.Parse(rawUserId);
//             var result = await _authService.Get(userId);
//             return Response<UserResponse>.Ok(result);
//         }

//         [HttpPost]
//         [Route("login")]
//         public async Task<Response<LoginResponse>> Login([FromBody] LoginRequest loginRequest){
//             var result = await _authService.GetUserByFirebaseTokenAsync(loginRequest);
//             return Response<LoginResponse>.Ok(result);
//         }

//         [HttpDelete]
//         [Route("logout")]
//         public async Task<Response<bool>> Logout([FromBody] LogoutRequest logoutRequest)
//         {
//             string rawUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
//             if (rawUserId.IsNullOrEmpty())
//             {
//                 return Response<bool>.Ok("Invalid Token");
//             }
//             Guid userId = Guid.Parse(rawUserId);
//             var result = await _authService.Logout(userId, logoutRequest.FcmToken);
//             return Response<bool>.Ok(result);
//         }

//         [HttpPut]
//         [Route("me")]

//         public async Task<Response<UserResponse>> Update([FromBody] UpdateUserRequest request)
//         {
//             string rawUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
//             if (rawUserId.IsNullOrEmpty())
//             {
//                 return Response<UserResponse>.Ok("Invalid Token");
//             }
//             Guid userId = Guid.Parse(rawUserId);
//             var result = await _authService.Update(userId, request);
//             return Response<UserResponse>.Ok(result);
//         }




//     }
// }
