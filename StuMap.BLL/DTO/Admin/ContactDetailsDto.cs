using StuMap.DAL.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace StuMap.BLL.DTO.Admin
{
    public class ContactDetailsDto
    {
        public int Id { get; set; }

        [Required]
        public required string Subject { get; set; }

        [Required]
        public required string Message { get; set; }

        // todo: comeback here and clean up

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public TicketStatusEnum Status { get; set; }

        public bool IsRead { get; set; }

        public string? AdminReply { get; set; }

        public string? RejectionReason { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? RepliedAt { get; set; }
    }
}
