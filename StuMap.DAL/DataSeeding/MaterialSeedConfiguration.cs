using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StuMap.DAL.Models;

namespace StuMap.DAL.DataSeeding
{
    public class MaterialSeedConfiguration: IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            // Seed data for Material entity
            string userId1 = "E2E368AB-8D20-401B-826A-F591202E3D19";      //c
            string userId2 = "E746D970-DB04-4D42-9493-9173C7D13EE9";  //c
            string userId6 = "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67"; //c

            builder.HasData(
                new Material { 
                Id = 1,
                Title= "MDN Web Docs: Basic HTML Syntax",
                Description= "An authoritative, text-based guide by MDN Web Docs outlining elements, tags, attributes, and formatting requirements for standard web documents.",
                Url= "https://developer.mozilla.org/en-US/docs/Learn_web_development/Core/Structuring_content/Basic_HTML_syntax",
                MaterialTypeId=1,
                ContributorId= "E2E368AB-8D20-401B-826A-F591202E3D19",
                CourseId=1,
                DateCreated= DateTime.Parse("2026-05-17 03:29:48.8080706"),
                },
                new Material
                {
                Id = 2,
                Title = "W3Schools: HTML Tutorial",
                Description = "An interactive web-based sandbox tool from W3Schools allowing you to write basic markup and instantly preview rendered headings, links, and text formatting.",
                Url = "https://www.w3schools.com/Html/",
                MaterialTypeId = 1,
                ContributorId = "E2E368AB-8D20-401B-826A-F591202E3D19",
                CourseId = 1,
                DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                },
                new Material
                {
                Id = 3,
                Title = "freeCodeCamp: Learn HTML Full Tutorial for Beginners",
                Description = "A comprehensive, four-hour structural video layout tutorial hosted on YouTube via freeCodeCamp designed to advance beginners through core content tagging.",
                Url = "https://www.youtube.com/watch?v=kUMe1FH4CHE",
                MaterialTypeId = 3,
                ContributorId = "E2E368AB-8D20-401B-826A-F591202E3D19",
                CourseId = 1,
                DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                },
                new Material
                {
                Id = 4,
                Title = "MDN Web Docs: CSS First Steps",
                Description = "A foundational guide on MDN Web Docs detailing cascade inheritance, standard syntax declarations, color applications, and fundamental font properties.",
                Url = "https://developer.mozilla.org/en-US/docs/Web/CSS",
                MaterialTypeId = 1,
                ContributorId = "E2E368AB-8D20-401B-826A-F591202E3D19",
                CourseId = 2,
                DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                },
                new Material
                {
                Id = 5,
                Title = "freeCodeCamp: CSS Tutorial – Full Course for Beginners",
                Description = "A focused structural design video playlist from freeCodeCamp demonstrating visual layout selectors, custom borders, elements padding, and style rules.",
                Url ="https://www.youtube.com/watch?v=OXGznpKZ_sA",
                MaterialTypeId = 3,
                ContributorId = "E2E368AB-8D20-401B-826A-F591202E3D19",
                CourseId = 2,
                DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                },
                new Material
                {
                Id = 6,
                Title = "W3Schools: Online CSS Tutorials",
                Description = "A modular web text environment via W3Schools with quick templates, text-align rules, custom backgrounds, and step-by-step styling exercises.",
                Url = "https://www.w3schools.com/css/",
                MaterialTypeId = 1,
                ContributorId = "E2E368AB-8D20-401B-826A-F591202E3D19",
                CourseId = 2,
                DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                },
                new Material
                {
                Id = 7,
                Title = "freeCodeCamp: HTML & CSS Full Course - Beginner to Pro",
                Description = "An intensive project-based video on YouTube via SuperSimpleDev/freeCodeCamp mapping responsive website components and complex grid layouts.",
                Url = "https://www.youtube.com/watch?v=G3e-cpL7ofc",
                MaterialTypeId = 3,
                ContributorId = "E2E368AB-8D20-401B-826A-F591202E3D19",
                CourseId = 3,
                DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                },
                new Material
                {
                Id = 8,
                Title = "W3Schools: Build Responsive Sites with W3.CSS",
                Description = "An instructional web framework guide by W3Schools showcasing dynamic viewport adjustments and screen-fluid grid column behaviors.",
                Url = "https://www.w3schools.com/css/",
                MaterialTypeId = 1,
                ContributorId = "E2E368AB-8D20-401B-826A-F591202E3D19",
                CourseId = 3,
                DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                },
                new Material
                {
                Id = 9,
                Title = "MDN Web Docs: Adding JavaScript to an HTML File",
                Description = "A technical deployment article from MDN Web Docs explaining script tag execution order, variable linkage, and element handling scripts.",
                Url = "https://developer.mozilla.org/en-US/docs/Web/HTML",
                MaterialTypeId = 1,
                ContributorId = "E746D970-DB04-4D42-9493-9173C7D13EE9",
                CourseId = 4,
                DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                },
                new Material
                {
                Id = 10,
                Title = "freeCodeCamp: Learn JavaScript Full Course for Beginners",
                Description = "A comprehensive foundational video course on YouTube via freeCodeCamp exploring programmatic statements, custom functions, and interactive button bindings.",
                Url = "https://www.youtube.com/c/Freecodecamp",
                MaterialTypeId = 3,
                ContributorId = "E746D970-DB04-4D42-9493-9173C7D13EE9",
                CourseId = 4,
                DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                },
                new Material
                {
                    Id = 11,
                    Title = "W3Schools: JavaScript Interactive Reference",
                    Description = "A live programming sandbox on W3Schools providing quick snippets to modify document style properties dynamically via user clicks.",
                    Url = "https://www.w3schools.com/js/",
                    MaterialTypeId = 1,
                    ContributorId = "E746D970-DB04-4D42-9493-9173C7D13EE9",
                    CourseId = 4,
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                }, 
                /**********************/
                new Material
                {
                    Id = 12,
                    Title = "HTML Basics Article",
                    Description = "Introduction to HTML tags and structure.",
                    Url = "https://example.com/html-basics",
                    MaterialTypeId = 1, // Article
                    ContributorId = userId1,
                    CourseId = 1, // Intro to HTML
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    //IsApproved = true
                },
                new Material
                {
                    Id = 13,
                    Title = "CSS Flexbox Video",
                    Description = "Learn how to use flexbox for layouts.",
                    Url = "https://example.com/css-flexbox-video",
                    MaterialTypeId = 2, // Video
                    ContributorId = userId1,
                    CourseId = 2, // Advanced CSS
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    //IsApproved = false
                },
                new Material
                {
                    Id = 14,
                    Title = "JavaScript Fundamentals Book",
                    Description = "Comprehensive guide to JavaScript basics.",
                    Url = "https://example.com/js-fundamentals-book",
                    MaterialTypeId = 3, // Book
                    ContributorId = userId2, 
                    CourseId = 4, 
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    //IsApproved = true
                },
                new Material
                {
                    Id = 15,
                    Title = "Python for Data Science Tutorial",
                    Description = "Hands-on tutorial for Python data analysis.",
                    Url = "https://example.com/python-data-science",
                    MaterialTypeId = 1, 
                    ContributorId = userId2,
                    CourseId = 4, // Python for Data Science
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    //IsApproved = false
                },
                new Material
                {
                    Id = 16,
                    Title = "Machine Learning Research Paper",
                    Description = "Exploring supervised learning algorithms.",
                    Url = "https://example.com/ml-research-paper",
                    MaterialTypeId = 6, // Research Paper
                    ContributorId = userId2,
                    CourseId = 6, // Machine Learning Basics
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    //IsApproved = true
                },
                new Material
                {
                    Id = 17,
                    Title = "Cybersecurity Fundamentals Exam",
                    Description = "Test your knowledge of cybersecurity basics.",
                    Url = "https://example.com/cybersecurity-exam",
                    MaterialTypeId = 6, // Exam
                    ContributorId = userId2,
                    CourseId = 7, 
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    //IsApproved = false
                },
                new Material
                {
                    Id = 18,
                    Title = "Flutter Mobile Development Video",
                    Description = "Build cross-platform apps with Flutter.",
                    Url = "https://example.com/flutter-video",
                    MaterialTypeId = 3, // Video
                    ContributorId = userId6,
                    CourseId = 8, // Mobile App Development
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    //IsApproved = true
                },
                new Material
                {
                    Id = 19,
                    Title = "Azure Cloud Presentation",
                    Description = "Overview of Azure cloud services.",
                    Url = "https://example.com/azure-presentation",
                    MaterialTypeId = 1,
                    ContributorId = userId6,
                    CourseId = 9, // Cloud Computing with Azure
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    //IsApproved = false
                },
                new Material
                {
                    Id = 20,
                    Title = "Docker & Kubernetes Podcast",
                    Description = "Discussion on containerization and orchestration.",
                    Url = "https://example.com/devops-podcast",
                    MaterialTypeId = 3, 
                    ContributorId = userId6,
                    CourseId = 10, // DevOps with Docker & Kubernetes
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    //IsApproved = true
                },
                new Material
                {
                    Id = 21,
                    Title = "Unity Game Development Image",
                    Description = "Visual guide to Unity interface.",
                    Url = "https://example.com/unity-image",
                    MaterialTypeId = 4, 
                    ContributorId = userId6,
                    CourseId = 11, // Game Development with Unity
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    //IsApproved = false
                },
                new Material
                {
                    Id = 22,
                    Title = "Network Types",
                    Description = "Explore all Network Types And learn How it works",
                    Url = "https://example.com/network-types",
                    MaterialTypeId = 4,
                    ContributorId = userId6,
                    CourseId = 12, 
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    //IsApproved = false
                },
                new Material
                {
                    Id = 23,
                    Title = "Network Layers",
                    Description = "Explore all Network Layers And learn How it works",
                    Url = "https://example.com/network-Layers",
                    MaterialTypeId = 4,
                    ContributorId = userId6,
                    CourseId = 12, 
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    //IsApproved = false
                },
                new Material
                {
                    Id = 24,
                    Title = "Python basics",
                    Description = "python guide for beginners",
                    Url = "https://example.com/Python-basics",
                    MaterialTypeId = 4,
                    ContributorId = userId2,
                    CourseId = 5, 
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    //IsApproved = false
                },
                new Material
                {
                    Id = 25,
                    Title = "NumPy Library in Python",
                    Description = "Learn how to use NumPy in Python",
                    Url = "https://example.com/Numpy",
                    MaterialTypeId = 4,
                    ContributorId = userId2,
                    CourseId = 5, 
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706"),
                    //IsApproved = false
                }
            );
        }
    }
}
