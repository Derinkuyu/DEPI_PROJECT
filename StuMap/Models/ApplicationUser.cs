using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StuMap.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [PersonalData]
        public string? FirstName { get; set; }

        [Required]
        [PersonalData]
        public string? LastName { get; set; }

        [Required]
        public string? Country { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
