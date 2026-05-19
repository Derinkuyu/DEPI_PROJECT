using System.ComponentModel.DataAnnotations;

namespace StuMap.ViewModels.Account
{
    public class AccountEditViewModel
    {
        //[Required]
        //[EmailAddress]
        //public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
