namespace StuMap.Models
{
    public class MaterialType
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public virtual List<Material>? Materials { get; set; }
    }
}
