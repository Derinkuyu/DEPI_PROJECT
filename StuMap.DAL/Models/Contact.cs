using StuMap.DAL.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace StuMap.DAL.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public string Subject { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string Body { get; set; } = string.Empty;
        public DateTime DateSent { get; set; } = DateTime.Now;
        public TicketStatusEnum Status { get; set; } = TicketStatusEnum.Pending;

        // todo: how will replies be handled?
        public string? AdminReply { get; set; }

        public DateTime? RepliedAt { get; set; }

        public string? RejectionReason { get; set; }
        public bool IsRead { get; set; }


    }
}
