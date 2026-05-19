using Microsoft.AspNetCore.Identity;
using StuMap.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace StuMap.Models
{
    public class ApplicationUser : IdentityUser
    {
        /*---------------------------------------------------------------------------------*/
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
        /*---------------------------------------------------------------------------------*/
        public bool IsBlocked { get; set; } = false;

        public DateTime CreatedAt { get; set; }

        /*---------------------------------------------------------------------------------*/
        public bool? IsContributorRequest { get; set; } = true;
        public string? Specialization { get; set; }

        public ContributorStatus? ContributorStatus { get; set; } = Enums.ContributorStatus.Pending;

        public string? RejectionReason { get; set; }

        public string? CertificatePath { get; set; }

        public DateTime? RequestDate { get; set; }

        /*---------------------------------------------------------------------------------*/
    }
}
