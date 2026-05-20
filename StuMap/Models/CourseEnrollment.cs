using Microsoft.AspNetCore.Identity;

namespace StuMap.Models
{
    public class CourseEnrollment
    {
        public string StudentId { get; set; }
        public ApplicationUser? Student { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public DateTime DateEnrolled { get; set; } = DateTime.Now;
    }
}
