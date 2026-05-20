using StuMap.Models;
using StuMap.Models.Enums;

namespace StuMap.DTO.Admin
{
    public class CourseDetailsDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ContributorName { get; set; }

        public string ContributorEmail { get; set; }

        public string? RoadmapName { get; set; }

        public CourseStatus Status { get; set; }

        public string? RejectionReason { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime SubmittedAt { get; set; }

        public DateTime? ApprovedAt { get; set; }

        public int MaterialsCount { get; set; }

        public IEnumerable<MaterialDto> Materials { get; set; }
    }
}
