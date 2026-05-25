using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StuMap.DAL.DataSeeding
{
    public class IdentityUserRoleSeedConfiguration: IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "074B369D-5560-4ADA-99D2-F8AECF1E2423",
                    RoleId = "E2845098-5312-4925-94B7-2ED3664CA318"
                },
                new IdentityUserRole<string>
                {
                    UserId = "B1364EFC-1779-4C6E-9623-0010F8F9EE89",
                    RoleId = "CB821695-B43A-41B9-8490-15A250D25FB5"
                },
                new IdentityUserRole<string>
                {
                    UserId = "E2E368AB-8D20-401B-826A-F591202E3D19",
                    RoleId = "2C4560E3-B816-43E5-8DA9-15C94336DC72"
                },
                new IdentityUserRole<string>
                {
                    UserId = "E746D970-DB04-4D42-9493-9173C7D13EE9",
                    RoleId = "2C4560E3-B816-43E5-8DA9-15C94336DC72"
                }
            );
        }
    }
}
