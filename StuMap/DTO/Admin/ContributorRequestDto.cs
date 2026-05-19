using StuMap.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace StuMap.DTO.Admin
{
    public class ContributorRequestDto
    {
        [Required]
        public required string Id { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Specialization { get; set; }

        public string? CertificatePath { get; set; }
        public ContributorStatus Status { get; set; }

        public DateTime? RequestDate { get; set; }      
    }
}
