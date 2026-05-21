namespace StuMap.Models
{
    public class RoadmapEnrollment
    {
        public string StudentId { get; set; }
        public ApplicationUser? Student { get; set; }
        public int RoadmapId { get; set; }
        public Roadmap? Roadmap { get; set; }
        public DateTime DateEnrolled { get; set; } = DateTime.Now;

        public virtual List<StudentRoadmapProgress>? StudentRoadmapProgress { get; set; }
        // todo: need a way to track progress through the roadmap
    }
}
