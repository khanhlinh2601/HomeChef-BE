using HC.Application.Common.Interfaces;
using HC.Application.Common.Model;
using HC.Domain.Dto.Requests;
using HC.Domain.Dto.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Response<UserResponse>> GetById(Guid id)
        {
            var result = await _userService.GetById(id);
            return Response<UserResponse>.Ok(result);
        }

        [HttpPost]
        public async Task<Response<bool>> Create([FromBody] CreateUserRequest request)
        {
            var result = await _userService.Create(request);
            return Response<bool>.Ok(result);
        }

        [HttpGet]
        public async Task<Response<IEnumerable<UserResponse>>> GetAll()
        {
            var result = await _userService.GetAll();
            return Response<IEnumerable<UserResponse>>.Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<Response<bool>> Update(Guid id, [FromBody] UpdateUserRequest request)
        {
            var result = await _userService.Update(id, request);
            return Response<bool>.Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<Response<bool>> Delete(Guid id)
        {
            var result = await _userService.Delete(id);
            return Response<bool>.Ok(result);
        }

    }
}
