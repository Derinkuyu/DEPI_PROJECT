using StuMap.DAL.Models;
using StuMap.DAL.Models.Enums;

namespace StuMap.BLL.DTO.Admin
{
    public class RoadmapDetailsDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string Description { get; set; }

        public string Specialization { get; set; }

        public string ContributorName { get; set; }

        public string ContributorEmail { get; set; }

        public StatusEnum Status { get; set; }

        public string? RejectionReason { get; set; }

        public DateTime SubmittedAt { get; set; }

        public DateTime? ApprovedAt { get; set; }

        public List<Course> Courses { get; set; }
    }
}
