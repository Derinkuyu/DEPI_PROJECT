namespace StuMap.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<Roadmap> Roadmaps { get; set; } = [];
    }
}
