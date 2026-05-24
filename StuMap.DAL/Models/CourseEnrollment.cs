using System.ComponentModel.DataAnnotations;

namespace StuMap.DAL.Models
{
    public class CourseEnrollment
    {
        [Required]
        public required string StudentId { get; set; }
        public ApplicationUser? Student { get; set; }
        [Required]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public DateTime DateEnrolled { get; set; } = DateTime.Now;
    }
}
