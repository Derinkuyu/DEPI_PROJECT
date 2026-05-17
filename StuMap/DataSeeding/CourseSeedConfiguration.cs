using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StuMap.Models;

namespace StuMap.DataSeeding
{
    public class CourseSeedConfiguration: IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // Seed data for Course entity
            builder.HasData(
                new Course {
                    Id = 1,
                    Title = "Introduction to HTML5",
                    ContributorId= "E2E368AB-8D20-401B-826A-F591202E3D19",
                    DateCreated= DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    Description = "Learn the absolute basics of building web pages. Master the structure of a website using text elements, hyperlinks, forms, images, and semantic tags that help search engines understand your content." 
                
                },
                new Course {
                    Id = 2,
                    ContributorId = "E2E368AB-8D20-401B-826A-F591202E3D19",
                    Title = "Introduction to CSS3",
                    DateCreated = DateTime.Parse("2026-05-16 03:29:48.8080706"),
                    Description = "Transform plain text into beautiful, styled web pages. Discover colors, custom fonts, borders, margins, padding, and how to use selectors to target and style specific elements across your site." },
                new Course {
                    Id = 3,
                    ContributorId = "E2E368AB-8D20-401B-826A-F591202E3D19",
                    DateCreated = DateTime.Parse("2026-05-15 03:29:48.8080706"),
                    Title = "Creating Responsive Web Designs",
                    Description = "Learn how to make your websites look perfect on any screen size. Master modern layouts using CSS Flexbox and Grid, and use media queries to automatically adapt designs for mobile phones, tablets, and desktops." },
                new Course { 
                    Id = 4,
                    ContributorId = "E746D970-DB04-4D42-9493-9173C7D13EE9",
                    DateCreated = DateTime.Parse("2026-05-14 03:29:48.8080706"),
                    Title = "Basic JavaScript for the Web",
                    Description = "Bring your static web pages to life with interactivity. Learn the fundamentals of programming—like variables, functions, and events—to handle user clicks, toggle menus, and create dynamic content." }
            );
        }
    }
}
