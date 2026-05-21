using StuMap.Models.Enums;

namespace StuMap.Models
{
    public class Roadmap
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }

        // Roadmap Creator
        public string? ContributorId { get; set; }
        public ApplicationUser? Contributor { get; set; }

        // Roadmap Specialization
        public int? SpecializationId { get; set; }
        public Specialization? Specialization { get; set; }

        // todo: need to figure out if list works with EF Core
        //public List<string> Tags { get; set; } = [];

        // Roadmap Enrollments
        public virtual List<ApplicationUser>? Students { get; set; }
        public virtual List<RoadmapEnrollment>? Enrollments { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        // required for admin approval before being displayed on the site
        public bool IsApproved { get; set; }

        // todo: how to show roadmap plan?

        public virtual List<CourseRoadmap>? CourseRoadmaps { get; set; }

        /*------------------------------------------------------------------------------*/
        //////For Manage RoadMap
        /*------------------------------------------------------------------------------*/
        public RoadmapStatus Status { get; set; }

        public string? RejectionReason { get; set; }

        public DateTime SubmittedAt { get; set; }

        public DateTime? ApprovedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
