namespace StuMap.Models
{
    public class Material
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public enum MaterialTypes { Article, Paper, Video, Image, Book, Exam, Other }
        public MaterialTypes MaterialType { get; set; } = MaterialTypes.Other;

        // Material Creator
        public int? ContributorId { get; set; }
        public Contributor? Contributor { get; set; }

        // Material Course
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        // required for admin approval before being displayed on the site
        public bool IsApproved { get; set; } = false;
    }
}
