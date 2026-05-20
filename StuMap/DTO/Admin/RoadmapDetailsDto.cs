using StuMap.Models;
using StuMap.Models.Enums;

namespace StuMap.DTO.Admin
{
    public class RoadmapDetailsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Specialization { get; set; }

        public string ContributorName { get; set; }

        public string ContributorEmail { get; set; }

        public RoadmapStatus Status { get; set; }

        public string? RejectionReason { get; set; }

        public DateTime SubmittedAt { get; set; }

        public DateTime? ApprovedAt { get; set; }

        public List<Course> Courses { get; set; }
    }
}
