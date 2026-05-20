using Microsoft.AspNetCore.Mvc;
using StuMap.DTO.Firebase;
using StuMap.Managers;
using System.Security.Claims;

namespace StuMap.Controllers
{
    public class NotificationController : Controller
    {
        INotificationManager notificationManager;
        public NotificationController(INotificationManager notificationManager)
        {
            this.notificationManager = notificationManager;
        }

        [HttpPost]
        public IActionResult SaveToken([FromBody] DeviceTokenDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) 
                return Unauthorized();
            if(!notificationManager.IsTokenExists(userId, dto.Token))
                notificationManager.AddDeviceToken(userId, dto.Token);
            return Ok();
        }
    }
}
