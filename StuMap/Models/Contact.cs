using StuMap.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace StuMap.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public string Subject { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        public string Body { get; set; } = string.Empty;
        public DateTime DateSent { get; set; } = DateTime.Now;
        public TicketStatus Status { get; set; } = TicketStatus.Pending;

        // todo: how will replies be handled?
        public string? AdminReply { get; set; }

        public DateTime? RepliedAt { get; set; }

        public string? RejectionReason { get; set; }
        public bool IsRead { get; set; }


    }
}
