using Microsoft.EntityFrameworkCore;
using StuMap.Models;

namespace StuMap.DataSeeding
{
    public class RoadmapSeedConfiguration : IEntityTypeConfiguration<Roadmap>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Roadmap> builder)
        {
            var conId= "E2E368AB-8D20-401B-826A-F591202E3D19";
            // Seed data for Roadmap entity
            builder.HasData(
                new Roadmap
                {
                    Id = 1,
                    Title = "Web development",
                    Description = "Web development is the process of designing, building, and maintaining websites and web applications, combining both creative design and technical programming to deliver functional, user-friendly digital experiences. It includes front-end (what users see), back-end (server, database, logic), and full-stack (both sides) development",
                    ContributorId= conId,
                    SpecializationId = 1,
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706")
                },
                new Roadmap
                {
                    Id = 2,
                    Title = "Frontend Path",
                    Description = "Frontend development focuses on everything the user sees and interacts with in the browser. It’s about turning design mockups (like the Figma prototype you have open) into functional, responsive, and engaging web pages.",
                    ContributorId = conId,
                    SpecializationId = 2,
                    DateCreated = DateTime.Parse("2026-05-17 03:29:48.8080706")
                }
            );
        }
    }
}