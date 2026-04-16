namespace StuMap.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public DateTime DateSent { get; set; } = DateTime.Now;

        // todo: how will replies be handled?

    }
}
