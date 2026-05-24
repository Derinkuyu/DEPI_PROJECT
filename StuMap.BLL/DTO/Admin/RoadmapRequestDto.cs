using StuMap.DAL.Models.Enums;

namespace StuMap.BLL.DTO.Admin
{
    public class RoadmapRequestDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Specialization { get; set; }

        public string? ContributorName { get; set; }

        public StatusEnum Status { get; set; }

        public DateTime SubmittedAt { get; set; }

        public int CoursesCount { get; set; }
    }
}
