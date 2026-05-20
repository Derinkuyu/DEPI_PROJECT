using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using StuMap.Context;
using StuMap.Managers;
using StuMap.Models;
using System.Security.Claims;
namespace StuMap.Services
{
    public class NotificationRepository : INotificationManager
    {
        AppDbContext context;
        public NotificationRepository(AppDbContext context)
        {
            this.context = context;
            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromFile("firebase-adminsdk.json")
                });
            }
        }
        public bool IsTokenExists(string userId, string deviceToken)
        {
            return context.UsersDeviceTokens.Any(x => x.UserId == userId && x.DeviceToken == deviceToken);
        }
        public void AddDeviceToken(string userId, string deviceToken)
        {
            var exists = context.UsersDeviceTokens.Any(x => x.UserId == userId && x.DeviceToken == deviceToken);
            if (!exists)
            {
                context.UsersDeviceTokens.Add(new UserDeviceToken
                {
                    UserId = userId,
                    DeviceToken = deviceToken,
                    DateAdded = DateTime.UtcNow
                });
                context.SaveChanges();
            }
        }
        public async Task SendNotificationAsync(string deviceToken, string title, string body)
        {
            var message = new Message
            {
                Token = deviceToken,
                Notification = new Notification
                {
                    Title = title,
                    Body = body
                }
            };
            await FirebaseMessaging.DefaultInstance.SendAsync(message);
        }
    }
}
