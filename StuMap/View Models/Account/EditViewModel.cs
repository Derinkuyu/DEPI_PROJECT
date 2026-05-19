using System.ComponentModel.DataAnnotations;

namespace StuMap.ViewModels.Account
{
    public class EditViewModel
    {
        [EmailAddress]
        public string? Email { get; set; }

        [Display(Name = "First Name")]
        public string? FName { get; set; }

        [Display(Name = "Last Name")]
        public string? LName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }
    }
}
