using StuMap.DAL.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace StuMap.BLL.DTO.Admin
{
    public class ContributorDetailsDto
    {
        [Required]
        public required string Id { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Specialization { get; set; }

        public string? CertificatePath { get; set; }

        public StatusEnum Status { get; set; }

        public string? RejectionReason { get; set; }

        public DateTime? RequestDate { get; set; }
    }
}
