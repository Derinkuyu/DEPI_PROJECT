namespace StuMap.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        // Certificate Holder
        public int ContributorId { get; set; }
        public Contributor? Contributor { get; set; }

        // todo: date uploaded to site or date issued by issuer?
        public DateTime DateIssued { get; set; } = DateTime.Now;

        public string Url { get; set; } = string.Empty;

        // required for admin approval before being displayed on the site
        public bool Approved { get; set; } = false;

    }
}
