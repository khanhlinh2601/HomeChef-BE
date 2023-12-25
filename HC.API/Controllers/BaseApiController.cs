using Microsoft.AspNetCore.Mvc;

namespace HC.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class BaseApiController : ControllerBase
{
}