using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StuMap.Models;

namespace StuMap.DataSeeding
{
    public class SpecializationSeedConfiguration: IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            // Seed data for Specialization entity
            builder.HasData(
                new Specialization { Id = 1, Name = "Computer Science", Description = "Computer Science studies how computers work, focusing on algorithms, data, and problem‑solving. It blends theory and practice to build systems like AI, databases, and operating systems." },
                new Specialization { Id = 2, Name = "Information Technology",Description = "Information Technology applies computer systems to manage and secure data. It covers networks, servers, and user support, ensuring organizations run smoothly with reliable tech." },
                new Specialization { Id = 3, Name = "Software Engineering", Description = "Software Engineering designs and builds software using structured methods. It emphasizes quality, scalability, and teamwork across the full lifecycle—from planning to maintenance." }
            );
        }
    }
}
