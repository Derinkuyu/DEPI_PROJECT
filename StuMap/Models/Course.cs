namespace StuMap.Models
{
    public class Course
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;

        // Course Creator
        public int? ContributorId { get; set; }
        public Contributor? Contributor { get; set; }

        // Course Roadmap
        public int RoadmapId { get; set; }
        public Roadmap? Roadmap { get; set; }

        public ICollection<Material> Materials { get; set; } = [];

        // todo: need to figure out if list works with EF Core
        //public List<string> Tags { get; set; } = [];

        public DateTime DateCreated { get; set; } = DateTime.Now;

        // required for admin approval before being displayed on the site
        public bool IsApproved { get; set; } = false;

    }
}
