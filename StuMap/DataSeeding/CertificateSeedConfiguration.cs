using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StuMap.Models;

namespace StuMap.DataSeeding
{
    public class CertificateSeedConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            // Seed data for Course entity
            string userId1 = "E2E368AB-8D20-401B-826A-F591202E3D19";      //c
            string userId2 = "E746D970-DB04-4D42-9493-9173C7D13EE9";  //c
            string userId6 = "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67"; //c

            builder.HasData(
                new Certificate
                {
                    Id = 1,
                    Title = "Frontend Development Certificate",
                    ContributorId = userId1,
                    DateIssued = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Url = "https://example.com/certificates/frontend",
                    Approved = true
                },
                new Certificate
                {
                    Id = 2,
                    Title = "Data Science Certificate",
                    ContributorId = userId2, 
                    DateIssued = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Url = "https://example.com/certificates/datascience",
                    Approved = true
                },
                new Certificate
                {
                    Id = 3,
                    Title = "Cybersecurity Fundamentals",
                    ContributorId = userId2,
                    DateIssued = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Url = "https://example.com/certificates/cybersecurity",
                    Approved = true
                },
                new Certificate
                {
                    Id = 4,
                    Title = "Mobile App Development",
                    ContributorId = userId6,
                    DateIssued = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Url = "https://example.com/certificates/mobile",
                    Approved = true
                },
                new Certificate
                {
                    Id = 5,
                    Title = "Cloud Computing with Azure",
                    ContributorId = userId6,
                    DateIssued = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Url = "https://example.com/certificates/cloud",
                    Approved = true
                },
                new Certificate
                {
                    Id = 6,
                    Title = "Artificial Intelligence",
                    ContributorId = userId2,
                    DateIssued = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Url = "https://example.com/certificates/ai",
                    Approved = true
                },
                new Certificate
                {
                    Id = 8,
                    Title = "DevOps Practices",
                    ContributorId = userId6,
                    DateIssued = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Url = "https://example.com/certificates/devops",
                    Approved = true
                },
                new Certificate
                {
                    Id = 9,
                    Title = "Game Development with Unity",
                    ContributorId = userId6,
                    DateIssued = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Url = "https://example.com/certificates/game",
                    Approved = true
                },
                new Certificate
                {
                    Id = 10,
                    Title = "Networking Essentials",
                    ContributorId = userId2,
                    DateIssued = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Url = "https://example.com/certificates/networking",
                    Approved = true
                }

                );
        }
    }
}
