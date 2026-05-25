using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StuMap.DAL.Models;
using StuMap.DAL.Models.Enums;

namespace StuMap.DAL.DataSeeding
{
    public class CourseSeedConfiguration: IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // Seed data for Course entity
            string userId1 = "E2E368AB-8D20-401B-826A-F591202E3D19";      //c
            string userId2 = "E746D970-DB04-4D42-9493-9173C7D13EE9";  //c
            string userId6 = "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67"; //c


            builder.HasData(
                new Course {
                    Id = 1,
                    Title = "Introduction to HTML5",
                    ContributorId= userId1,
                    DateCreated= DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Description = "Learn the absolute basics of building web pages. Master the structure of a website using text elements, hyperlinks, forms, images, and semantic tags that help search engines understand your content.",
                      Status = StatusEnum.Approved,
                },
                new Course {
                    Id = 2,
                    ContributorId = userId1,
                    Title = "Introduction to CSS3",
                    DateCreated = DateTime.Parse("2026-05-16 03:29:48.8080706"),
                    Description = "Transform plain text into beautiful, styled web pages. Discover colors, custom fonts, borders, margins, padding, and how to use selectors to target and style specific elements across your site.",
                      Status = StatusEnum.Approved,
                },
                new Course {
                    Id = 3,
                    ContributorId = userId1,
                    DateCreated = DateTime.Parse("2026-05-15 03:29:48.8080706"),
                    Title = "Creating Responsive Web Designs",
                    Description = "Learn how to make your websites look perfect on any screen size. Master modern layouts using CSS Flexbox and Grid, and use media queries to automatically adapt designs for mobile phones, tablets, and desktops.",
                      Status = StatusEnum.Approved,
                },
                new Course { 
                    Id = 4,
                    ContributorId = userId2,
                    DateCreated = DateTime.Parse("2026-05-14 03:29:48.8080706"),
                    Title = "Basic JavaScript for the Web",
                    Description = "Bring your static web pages to life with interactivity. Learn the fundamentals of programming—like variables, functions, and events—to handle user clicks, toggle menus, and create dynamic content.",
                     Status = StatusEnum.Approved,
                },
                new Course
                {
                    Id = 5,
                    Title = "Python for Data Science",
                    Description = "Learn Python basics, NumPy, and Pandas.",
                    ContributorId = userId2,
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Status = StatusEnum.Approved,
                    IsDeleted = false
                },
                new Course
                {
                    Id = 6,
                    Title = "Machine Learning Basics",
                    Description = "Supervised and unsupervised learning algorithms.",
                    ContributorId = userId2,
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Status = StatusEnum.Approved,
                    IsDeleted = false
                },
                new Course
                {
                    Id = 7,
                    Title = "Cybersecurity Fundamentals",
                    Description = "Network security, encryption, and ethical hacking.",
                    ContributorId = userId2,
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Status = StatusEnum.Approved,
                    IsDeleted = false
                },
                new Course
                {
                    Id = 8,
                    Title = "Mobile App Development with Flutter",
                    Description = "Cross-platform mobile apps using Flutter and Dart.",
                    ContributorId = userId6,
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Status = StatusEnum.Approved,
                    IsDeleted = false
                },
                new Course
                {
                    Id = 9,
                    Title = "Cloud Computing with Azure",
                    Description = "Learn Azure fundamentals and cloud-native services.",
                    ContributorId = userId6,
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Status = StatusEnum.Approved,
                    IsDeleted = false
                },
                new Course
                {
                    Id = 10,
                    Title = "DevOps with Docker & Kubernetes",
                    Description = "Containerization, orchestration, and CI/CD pipelines.",
                    ContributorId = userId6,
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Status = StatusEnum.Approved,
                    IsDeleted = false
                },
                new Course
                {
                    Id = 11,
                    Title = "Game Development with Unity",
                    Description = "Learn Unity basics and build interactive games.",
                    ContributorId = userId6,
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Status = StatusEnum.Approved,
                    IsDeleted = false
                },
                new Course
                {
                    Id = 12,
                    Title = "Network Essentials",
                    Description = "Learn basics of network and Its layers",
                    ContributorId = userId6,
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Status = StatusEnum.Approved,
                    IsDeleted = false
                }

            );
        }
    }
}
