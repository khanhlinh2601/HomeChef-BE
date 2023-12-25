using FirebaseAdmin.Messaging;
using HC.Application.Common.Interfaces;

namespace HC.Application.Services;

public class NotificationService : INotificationService
{
    public async Task<string> SendNotificationMultiDeviceAsync(List<string> fcmTokens, string title, string content)
    {
        var message = new MulticastMessage()
        {
            Notification = new FirebaseAdmin.Messaging.Notification()
            {
                Title = title,
                Body = content
            },
            Tokens = fcmTokens

        };
        BatchResponse response = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(message);
        return response.SuccessCount.ToString();
    }
    public async Task<string> SendNotificationOneDeviceAsync(string fcmToken, string title, string content)
    {
        var message = new Message()
        {
            Notification = new FirebaseAdmin.Messaging.Notification()
            {
                Title = title,
                Body = content
            },
            Token = fcmToken

        };
        string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
        return response;
    }
}

