using StuMap.DAL.Models.Enums;

namespace StuMap.DAL.Models
{
    public class Roadmap
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }

        // Roadmap Creator
        public string? ContributorId { get; set; }
        public ApplicationUser? Contributor { get; set; }

        // Roadmap Specialization
        public int? SpecializationId { get; set; }
        public Specialization? Specialization { get; set; }

        // todo: need to figure out if list works with EF Core
        //public List<string> Tags { get; set; } = [];

        // Roadmap Enrollments
        public ICollection<ApplicationUser> Students { get; set; } = new HashSet<ApplicationUser>();
        public ICollection<RoadmapEnrollment> Enrollments { get; set; } = new HashSet<RoadmapEnrollment>();

        public DateTime DateCreated { get; set; } = DateTime.Now;

        // required for admin approval before being displayed on the site
        public bool IsApproved { get; set; }

        // todo: how to show roadmap plan?

        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();

        /*------------------------------------------------------------------------------*/
        //////For Manage RoadMap
        /*------------------------------------------------------------------------------*/
        public StatusEnum Status { get; set; } = StatusEnum.Pending;

        public string? RejectionReason { get; set; }

        public DateTime SubmittedAt { get; set; }

        public DateTime? ApprovedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
