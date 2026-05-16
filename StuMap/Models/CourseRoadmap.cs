namespace StuMap.Models
{
    public class CourseRoadmap
    {
        public int CourseId { set; get; }
        public virtual Course? Course { set; get; }
        public int RoadmapId { set; get; }
        public virtual Roadmap? Roadmap { set; get; }
    }
}
