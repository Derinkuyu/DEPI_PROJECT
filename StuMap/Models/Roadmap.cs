namespace StuMap.Models
{
    public class Roadmap
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;

        // Roadmap Creator
        public int? ContributorId { get; set; }
        public Contributor? Contributor { get; set; }

        // Roadmap Specialization
        public int? SpecializationId { get; set; }
        public Specialization? Specialization { get; set; }

        // todo: need to figure out if list works with EF Core
        //public List<string> Tags { get; set; } = [];

        // Roadmap Enrollments
        public ICollection<Student> Students { get; set; } = [];
        public ICollection<Enrollment> Enrollments { get; set; } = [];

        public DateTime DateCreated { get; set; } = DateTime.Now;

        // required for admin approval before being displayed on the site
        public bool IsApproved { get; set; } = false;

        // todo: how to show roadmap plan?

        public ICollection<Course> Courses { get; set; } = [];
    }
}
