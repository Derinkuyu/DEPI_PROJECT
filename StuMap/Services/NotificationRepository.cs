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
            var exists = IsTokenExists(userId , deviceToken);
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
        public string GetDeviceToken(string userId)
        {
            var token = context.UsersDeviceTokens.Where(x => x.UserId == userId).Select(x => x.DeviceToken).FirstOrDefault();
            return token;
        }
        public async Task SendNotificationAsync(string deviceToken, string title, string body)
        {
            if (string.IsNullOrEmpty(deviceToken)) return;

            try
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
            catch (FirebaseMessagingException ex) when (ex.MessagingErrorCode == MessagingErrorCode.InvalidArgument
                                          || ex.MessagingErrorCode == MessagingErrorCode.Unregistered)
            {
                context.UsersDeviceTokens.RemoveRange(
               context.UsersDeviceTokens.Where(x => x.DeviceToken == deviceToken));
                await context.SaveChangesAsync();
            }
        }
    }
}
