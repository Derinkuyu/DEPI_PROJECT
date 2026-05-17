using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StuMap.Models;

namespace StuMap.DataSeeding
{
    public class MaterialSeedConfiguration: IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            // Seed data for Material entity
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
                }
            );
        }
    }
}
