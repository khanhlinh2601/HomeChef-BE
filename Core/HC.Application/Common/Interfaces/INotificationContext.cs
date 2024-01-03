namespace HC.Application.Common.Interfaces;

public interface INotificationContext
{
    Task<string> SendNotificationMultiDeviceAsync(List<string> fcmTokens, string title, string content);
    Task<string> SendNotificationOneDeviceAsync(string fcmToken, string title, string content);

}
