namespace StuMap.DAL.Models
{
    public class RoadmapEnrollment
    {
        public required string StudentId { get; set; }
        public ApplicationUser? Student { get; set; }
        public required int RoadmapId { get; set; }
        public Roadmap? Roadmap { get; set; }
        public DateTime DateEnrolled { get; set; } = DateTime.Now;

        public ICollection<StudentRoadmapProgress> StudentRoadmapProgress { get; set; } = new HashSet<StudentRoadmapProgress>();
        // todo: need a way to track progress through the roadmap
    }
}
