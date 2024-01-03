
using HC.Application.Interfaces;
using HC.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HC.API.Controllers;

public class NotificationController : BaseApiController
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Notification>>> GetAll()
    {
        return Ok(await _notificationService.GetAll());
    }

    
    
}