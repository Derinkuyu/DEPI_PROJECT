using StuMap.DAL.Models.Enums;

namespace StuMap.DAL.Models
{
    public class Course
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;

        // Course Creator
        public string? ContributorId { get; set; }
        public ApplicationUser? Contributor { get; set; }

        // Course Roadmap
        public ICollection<Material> Materials { get; set; } = new HashSet<Material>();

        public ICollection<StudentRoadmapProgress> StudentRoadmapProgress { get; set; } = new HashSet<StudentRoadmapProgress>();

        // todo: need to figure out if list works with EF Core
        //public List<string> Tags { get; set; } = [];

        public DateTime DateCreated { get; set; } = DateTime.Now;  //when contriburer create a draft

        // required for admin approval before being displayed on the site
        public StatusEnum Status { get; set; } = StatusEnum.Pending;

        /*--------------------------------------------------------------------------------*/
        /////For Course Mangement
        /*--------------------------------------------------------------------------------*/

        public string? RejectionReason { get; set; }

        public DateTime SubmittedAt { get; set; } //when admin submit the course for approval

        public DateTime? ApprovedAt { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? LastUpdatedAt { get; set; }

    }
}
