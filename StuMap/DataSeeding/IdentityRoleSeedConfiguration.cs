using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StuMap.DataSeeding
{
    public class IdentityRoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            string ADMIN_ROLE_ID = "E2845098-5312-4925-94B7-2ED3664CA318";
            string STUDENT_ROLE_ID = "CB821695-B43A-41B9-8490-15A250D25FB5";
            string CONTRIBUTOR_ROLE_ID = "2C4560E3-B816-43E5-8DA9-15C94336DC72";
            builder.HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = ADMIN_ROLE_ID,
                ConcurrencyStamp = ADMIN_ROLE_ID
            },
            new IdentityRole
            {
                Name = "Student",
                NormalizedName = "STUDENT",
                Id = STUDENT_ROLE_ID,
                ConcurrencyStamp = STUDENT_ROLE_ID
            },
            new IdentityRole
            {
                Name = "Contributor",
                NormalizedName = "CONTRIBUTOR",
                Id = CONTRIBUTOR_ROLE_ID,
                ConcurrencyStamp = CONTRIBUTOR_ROLE_ID
            }
            );
        }
    }
}
