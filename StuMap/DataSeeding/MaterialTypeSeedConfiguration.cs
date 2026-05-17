using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StuMap.Models;

namespace StuMap.DataSeeding
{
    public class MaterialTypeSeedConfiguration : IEntityTypeConfiguration<MaterialType>

    {
        public void Configure(EntityTypeBuilder<MaterialType> builder)
        {
            builder.HasData(
                new MaterialType{Id=1,Title= "Article"},
                new MaterialType { Id = 2, Title = "Paper" },
                new MaterialType { Id = 3, Title = "Video" },
                new MaterialType { Id = 4, Title = "Image" },
                new MaterialType { Id = 5, Title = "Book" },
                new MaterialType { Id = 6, Title = "Exam" },
                new MaterialType { Id = 7, Title = "Other" }
                );
        }
    }
}
