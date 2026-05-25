using Microsoft.EntityFrameworkCore;
using StuMap.DAL.Models;
using StuMap.DAL.Models.Enums;

namespace StuMap.DAL.DataSeeding
{
    public class TicketSeedConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Contact> builder)
        {
            string STUDENT_ID = "B1364EFC-1779-4C6E-9623-0010F8F9EE89";


            builder.HasData(
                    new Contact
                    {
                        Id = 1,
                        UserId = STUDENT_ID,
                        Subject = "Issue with course content",
                        Body = "I am having trouble understanding the material in the course.",
                        DateSent = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                        Status = TicketStatusEnum.Considered,
                    },
                    new Contact
                    {
                        Id = 2,
                        UserId = STUDENT_ID,
                        Subject = "Feature request",
                        Body = "I would like to see a dark mode option in the app.",
                        DateSent = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                        Status = TicketStatusEnum.Denied,
                    },
                    new Contact
                    {
                        Id = 3,
                        UserId = STUDENT_ID,
                        Subject = "Bug report",
                        Body = "The app crashes when I try to access my profile.",
                        DateSent = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                        Status = TicketStatusEnum.Pending,
                    },
                    new Contact
                    {
                        Id = 4,
                        UserId = STUDENT_ID,
                        Subject = "Access Roadmap",
                        Body = "I can not accesss my saved Roadmaps.",
                        DateSent = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                        Status = TicketStatusEnum.Pending,
                    },
                    new Contact
                    {
                        Id = 5,
                        UserId = STUDENT_ID,
                        Subject = "Issue with course content",
                        Body = "I am having trouble understanding the material in the course.",
                        DateSent = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                        Status = TicketStatusEnum.Considered,
                    }

                );
        }

    }
}
