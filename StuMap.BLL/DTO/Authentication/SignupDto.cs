namespace StuMap.BLL.DTO.Authentication
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    // Tell the API engine to inspect the "AccountType" string in the JSON
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "AccountType")]
    [JsonDerivedType(typeof(StudentSignUpDto), typeDiscriminator: "Student")]
    [JsonDerivedType(typeof(ContributorSignUpDto), typeDiscriminator: "Contributor")]
    public abstract class SignupDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string? FName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string? LName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string? Country { get; set; }

        [Required]
        public string? Phone { get; set; }
    }

    // Subclass A
    public class StudentSignUpDto : SignupDto
    {

    }

    // Subclass B
    public class ContributorSignUpDto : SignupDto
    {
        public List<CertificateViewModel> Certificates { get; set; } = [];

        public class CertificateViewModel
        {
            [Required]
            public required string Title { get; set; }
            [Required]
            public required string Url { get; set; }
        }
    }
}
