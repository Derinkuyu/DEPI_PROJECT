using StuMap.Models.Enums;

namespace StuMap.DTO.Admin
{
    public class ContactDetailsDto
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public TicketStatus Status { get; set; }

        public bool IsRead { get; set; }

        public string? AdminReply { get; set; }

        public string? RejectionReason { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? RepliedAt { get; set; }
    }
}
