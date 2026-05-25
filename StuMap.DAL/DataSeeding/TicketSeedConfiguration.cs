using Microsoft.EntityFrameworkCore;
using StuMap.DAL.Models;
using StuMap.DAL.Models.Enums;

namespace StuMap.DAL.DataSeeding
{
    public class TicketSeedConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Contact> builder)
        {
  
            /*********/
            string userId1 = "E2E368AB-8D20-401B-826A-F591202E3D19"; // c
            string userId2 = "E746D970-DB04-4D42-9493-9173C7D13EE9";  //c
            string userId3 = "B1364EFC-1779-4C6E-9623-0010F8F9EE89";
            /*********/
            string userId5 = "3BD94FC0-7656-4EC5-9C8F-90897DD64BE5";
            string userId6 = "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67"; //c
            string userId7 = "B9ECCC1E-FF12-41D0-9BE9-83B8A57EB855";
            string userId8 = "8CBAA357-F2D9-48FC-B4BC-27AD0BD7C1EB";// c
            string userId9 = "E403198E-3791-46B5-8A8E-81F469A5B48E";
            builder.HasData(
                 new Contact
                 {
                     Id = 1,
                     UserId = userId5, // Ahmed Student
                     Subject = "Issue with course enrollment",
                     Body = "I tried enrolling in the HTML course but it failed.",
                     DateSent = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                     Status = TicketStatusEnum.Pending,
                     IsRead = false
                 },
                new Contact
                {
                    Id = 2,
                    UserId = userId6, // Sara Contributor
                    Subject = "Contributor request follow-up",
                    Body = "Can you update me on my contributor approval?",
                    DateSent = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Status = TicketStatusEnum.Pending,
                    IsRead = true
                },
                new Contact
                {
                    Id = 3,
                    UserId = userId7, // Mohamed Student
                    Subject = "Bug in roadmap progress",
                    Body = "My progress isn’t updating correctly.",
                    DateSent = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Status = TicketStatusEnum.Considered,
                    AdminReply = "We fixed the issue. Please try again.",
                    RepliedAt = DateTime.Parse("2026-05-18 03:29:48.8080706"),
                    IsRead = true
                },
                new Contact
                {
                    Id = 4,
                    UserId = userId2,
                    Subject = "Certificate upload issue",
                    Body = "I cannot upload my certificate file.",
                    DateSent = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Status = TicketStatusEnum.Denied,
                    RejectionReason = "File format not supported.",
                    IsRead = true
                },
                new Contact
                {
                    Id = 5,
                    UserId = userId3,
                    Subject = "Course feedback",
                    Body = "The HTML course was very helpful!",
                    DateSent = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Status = TicketStatusEnum.Considered,
                    AdminReply = "Thank you for your feedback.",
                    RepliedAt = DateTime.Parse("2026-05-18 03:29:48.8080706"),
                    IsRead = true
                },
                new Contact
                {
                    Id = 6,
                    UserId = userId2,
                    Subject = "Request for roadmap approval",
                    Body = "Please approve my frontend roadmap submission.",
                    DateSent = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Status = TicketStatusEnum.Pending,
                    IsRead = false
                },

                new Contact
                {
                    Id = 7,
                    UserId = userId2,
                    Subject = "Material approval request",
                    Body = "Please review my submitted material.",
                    DateSent = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Status = TicketStatusEnum.Considered,
                    IsRead = false
                },
                new Contact
                {
                    Id = 8,
                    UserId = userId3,
                    Subject = "Issue with course content",
                    Body = "I am having trouble understanding the material in the course.",
                    DateSent = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Status = TicketStatusEnum.Considered,
                },
                    new Contact
                    {
                        Id = 9,
                        UserId = userId3,
                        Subject = "Feature request",
                        Body = "I would like to see a dark mode option in the app.",
                        DateSent = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                        Status = TicketStatusEnum.Denied,
                    },
                    new Contact
                    {
                        Id = 10,
                        UserId = userId3,
                        Subject = "Bug report",
                        Body = "The app crashes when I try to access my profile.",
                        DateSent = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                        Status = TicketStatusEnum.Pending,
                    },
                    new Contact
                    {
                        Id = 11,
                        UserId = userId3,
                        Subject = "Access Roadmap",
                        Body = "I can not accesss my saved Roadmaps.",
                        DateSent = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                        Status = TicketStatusEnum.Pending,
                    },
                    new Contact
                    {
                        Id = 12,
                        UserId = userId3,
                        Subject = "Issue with course content",
                        Body = "I am having trouble understanding the material in the course.",
                        DateSent = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                        Status = TicketStatusEnum.Considered,
                    }
                );

        }

    }
}
