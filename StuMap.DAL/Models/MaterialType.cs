namespace StuMap.DAL.Models
{
    public class MaterialType
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public ICollection<Material> Materials { get; set; } = new HashSet<Material>();
    }
}
