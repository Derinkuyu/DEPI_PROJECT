using StuMap.Models.Enums;

namespace StuMap.DTO.Admin
{
    public class RoadmapRequestDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Specialization { get; set; }

        public string ContributorName { get; set; }

        public RoadmapStatus Status { get; set; }

        public DateTime SubmittedAt { get; set; }

        public int CoursesCount { get; set; }
    }
}
