namespace StuMap.Models
{
    public class Enrollment
    {
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int RoadmapId { get; set; }
        public Roadmap? Roadmap { get; set; }
        public DateTime DateEnrolled { get; set; } = DateTime.Now;

        // todo: need a way to track progress through the roadmap
    }
}
