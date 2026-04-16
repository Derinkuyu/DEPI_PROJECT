using System.ComponentModel.DataAnnotations;

namespace StuMap.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; } = string.Empty;
        public required string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}".Trim();


        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        // todo: how will this be handed?
        //public string ProfilePictureUrl { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public enum Genders { Male, Female }
        public Genders Gender { get; set; } = Genders.Male;

        public string Country { get; set; } = string.Empty;

        public ICollection<Contact> Contacts { get; set; } = [];
    }
}
