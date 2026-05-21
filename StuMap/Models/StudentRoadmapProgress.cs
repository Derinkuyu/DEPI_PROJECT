namespace StuMap.Models
{
    public class StudentRoadmapProgress
    {
        public string StudentId { get; set; }
        public ApplicationUser? Student { get; set; }
        public int RoadmapId { get; set; }
        public Roadmap? Roadmap { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
