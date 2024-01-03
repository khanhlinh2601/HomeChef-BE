
using HC.Application.Common.Persistence;
using Microsoft.Extensions.Logging;

namespace HC.Application.Services;

public class NotificationService : INotificationService
{
    private readonly IRepository<Notification> _notificationRepository;
    private readonly INotificationContext _notificationContext;
    private readonly ILogger<NotificationService> _logger;
    private readonly IUserService _userService;

    public NotificationService(IRepository<Notification> notificationRepository, INotificationContext notificationContext, ILogger<NotificationService> logger, IUserService userService)
    {
        _notificationRepository = notificationRepository;
        _notificationContext = notificationContext;
        _logger = logger;
        _userService = userService;
    }
    public async Task<Notification> CreateAsync(Notification notification)
    {
        List<string> fcmTokens = await _userService.GetFcmToken(notification.ReceiverId);


        await _notificationContext.SendNotificationMultiDeviceAsync(fcmTokens, notification.Title, notification.Description);
        return await _notificationRepository.AddAsync(notification);
    }

    public async Task<IEnumerable<Notification>> GetAll()
    {
        return await _notificationRepository.ListAsync();
    }
}