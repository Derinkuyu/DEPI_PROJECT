using System.ComponentModel.DataAnnotations;

namespace StuMap.BLL.DTO.Authentication
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        public string ?DeviceToken { get; set; }
    }
}
