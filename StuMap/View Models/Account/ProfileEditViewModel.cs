using System.ComponentModel.DataAnnotations;

namespace StuMap.ViewModels.Account
{
    public class ProfileEditViewModel
    {

        [Required]
        [Display(Name = "First Name")]
        public string? FName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string? LName { get; set; }

        public string? Phone { get; set; }

        [Required]
        public string? Country { get; set; }
    }
}
