namespace StuMap.BLL.DTO.Admin
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        // expose type/title for display
        public string MaterialType { get; set; } = string.Empty;
    }
}