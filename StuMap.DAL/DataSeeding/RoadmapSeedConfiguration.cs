using Microsoft.EntityFrameworkCore;
using StuMap.DAL.Models;
using StuMap.DAL.Models.Enums;

namespace StuMap.DAL.DataSeeding
{
    public class RoadmapSeedConfiguration : IEntityTypeConfiguration<Roadmap>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Roadmap> builder)
        {
            string userId1 = "E2E368AB-8D20-401B-826A-F591202E3D19";      //c
            string userId2 = "E746D970-DB04-4D42-9493-9173C7D13EE9";  //c
            string userId6 = "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67"; //c
           
            // Seed data for Roadmap entity
            builder.HasData(
                new Roadmap
                {
                    Id = 1,
                    Title = "Web development",
                    Description = "Web development is the process of designing, building, and maintaining websites and web applications, combining both creative design and technical programming to deliver functional, user-friendly digital experiences. It includes front-end (what users see), back-end (server, database, logic), and full-stack (both sides) development",
                    ContributorId = userId1,
                    SpecializationId = 1,
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Status = StatusEnum.Approved
                },
                new Roadmap
                {
                    Id = 2,
                    Title = "Frontend Path",
                    Description = "Frontend development focuses on everything the user sees and interacts with in the browser. It’s about turning design mockups (like the Figma prototype you have open) into functional, responsive, and engaging web pages.",
                    ContributorId = userId1,
                    SpecializationId = 2,
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Status = StatusEnum.Approved
                },

                //************/
                new Roadmap
                {
                    Id = 3,
                    Title = "Frontend Development Roadmap",
                    Description = "Step-by-step guide to becoming a frontend developer.",
                    ContributorId = userId6, // Sara Contributor
                    SpecializationId = 1, // Web Development
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    IsApproved = false,
                    Status = StatusEnum.Rejected,

                    IsDeleted = false
                },
                new Roadmap
                {
                    Id = 4,
                    Title = "Data Science Beginner Roadmap",
                    Description = "Learn Python, statistics, and machine learning basics.",
                    ContributorId = userId6, // Fatma Contributor
                    SpecializationId = 2, // Data Science
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    IsApproved = false,
                    Status = StatusEnum.Approved,
                    IsDeleted = false
                },
                new Roadmap
                {
                    Id = 5,
                    Title = "Cybersecurity Essentials",
                    Description = "Introduction to network security and ethical hacking.",
                    ContributorId = userId2, // Sara Contributor
                    SpecializationId = 3,
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    IsApproved = true,
                    Status = StatusEnum.Approved,
                    IsDeleted = false
                },
                new Roadmap
                {
                    Id = 6,
                    Title = "Mobile App Development Roadmap",
                    Description = "Learn Android and iOS development fundamentals.",
                    ContributorId = userId6,
                    SpecializationId = 4,
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    IsApproved = false,
                    Status = StatusEnum.Pending,
                    IsDeleted = false
                }
                //,
                //new Roadmap
                //{
                //    Id = 7,
                //    Title = "Cloud Computing Roadmap",
                //    Description = "Master AWS, Azure, and cloud-native tools.",
                //    ContributorId = userId1,
                //    SpecializationId = 5,
                //    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                //    IsApproved = true,
                //    Status = StatusEnum.Approved,
                //    IsDeleted = false
                //},
                //new Roadmap
                //{
                //    Id = 8,
                //    Title = "AI & Machine Learning Roadmap",
                //    Description = "Deep learning, NLP, and AI project building.",
                //    ContributorId = userId2,
                //    SpecializationId = 6,
                //    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                //    IsApproved = true,
                //    Status = StatusEnum.Approved,
                //    IsDeleted = false
                //},
                //new Roadmap
                //{
                //    Id = 10,
                //    Title = "DevOps Roadmap",
                //    Description = "CI/CD pipelines, Docker, Kubernetes, and automation.",
                //    ContributorId = userId1,
                //    SpecializationId = 8,
                //    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                //    IsApproved = false,
                //    Status = StatusEnum.Pending,
                //    IsDeleted = false
                //},
                //new Roadmap
                //{
                //    Id = 11,
                //    Title = "Game Development Roadmap",
                //    Description = "Learn Unity, Unreal Engine, and game design.",
                //    ContributorId = userId6,
                //    SpecializationId = 9,
                //    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                //    IsApproved = true,
                //    Status = StatusEnum.Approved,
                //    IsDeleted = false
                //}
            );
        }
    }
}