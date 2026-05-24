namespace StuMap.DAL.Models
{
    public class Material
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;
        //public enum MaterialTypes { Article, Paper, Video, Image, Book, Exam, Other }

        public int MaterialTypeId { get; set; }
        public virtual MaterialType? MaterialType { get; set; }

        // Material Creator
        public string? ContributorId { get; set; }
        public ApplicationUser? Contributor { get; set; }

        // Material Course
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
