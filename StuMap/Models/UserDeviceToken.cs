using Microsoft.AspNetCore.Identity;

namespace StuMap.Models
{
    public class UserDeviceToken
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public string DeviceToken { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; } = DateTime.Now;

    }
}
