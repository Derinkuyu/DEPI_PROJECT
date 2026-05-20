using StuMap.Models.Enums;

namespace StuMap.DTO.Admin
{
    public class CourseRequestDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int MaterialsCount { get; set; }

        public string ContributorName { get; set; }

        public string RoadmapName { get; set; }

        public CourseStatus Status { get; set; }

        public DateTime SubmittedAt { get; set; }
    }
}
