namespace HC.Application.Interfaces;

public interface INotificationService
{
    Task<Notification> CreateAsync(Notification notification);
    Task<IEnumerable<Notification>> GetAll();
}