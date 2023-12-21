﻿using FirebaseAdmin.Messaging;
using HC.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Application.Services
{
    public class NotificationService
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public NotificationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
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
}