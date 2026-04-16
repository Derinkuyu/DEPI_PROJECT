namespace StuMap.Models
{
    public class Student : User
    {
        // Student Roadmap Enrollments
        public ICollection<Roadmap> Roadmaps { get; set; } = [];
        public ICollection<Enrollment> Enrollments { get; set; } = [];
    }
}
