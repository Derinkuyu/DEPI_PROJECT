namespace StuMap.Models
{
    public class Contributor : User
    {
      public ICollection<Certificate> Certificates { get; set; } = [];
    }
}
