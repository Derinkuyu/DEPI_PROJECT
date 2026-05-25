using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StuMap.DAL.Models;

namespace StuMap.DAL.DataSeeding
{
    public class SpecializationSeedConfiguration: IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            // Seed data for Specialization entity
            builder.HasData(
               new Specialization { Id = 1, Name = "Web Development", Description = "Frontend and backend web technologies." },
                new Specialization { Id = 2, Name = "Data Science", Description = "Machine learning, statistics, and data analysis." },
                new Specialization { Id = 3, Name = "Cybersecurity", Description = "Protecting systems, networks, and data." },
                new Specialization { Id = 4, Name = "Mobile Development", Description = "Building apps for Android and iOS." },
                new Specialization { Id = 5, Name = "Cloud Computing", Description = "AWS, Azure, and cloud-native architectures." },
                new Specialization { Id = 6, Name = "Artificial Intelligence", Description = "Deep learning, NLP, and intelligent systems." },
                new Specialization { Id = 7, Name = "Software Testing", Description = "Manual and automated testing practices." },
                new Specialization { Id = 8, Name = "DevOps", Description = "CI/CD pipelines, containerization, and automation." },
                new Specialization { Id = 9, Name = "Game Development", Description = "Designing and programming interactive games." },
                new Specialization { Id = 10, Name = "Networking", Description = "Computer networks, protocols, and CCNA fundamentals." });

        }
    }
}
