using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StuMap.DataSeeding
{
    public class IdentityUserRoleSeedConfiguration: IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            string userId1 = "E2E368AB-8D20-401B-826A-F591202E3D19"; // c
            string userId2 = "E746D970-DB04-4D42-9493-9173C7D13EE9";  //c
            string userId3 = "B1364EFC-1779-4C6E-9623-0010F8F9EE89";  //s
            string userId4 = "074B369D-5560-4ADA-99D2-F8AECF1E2423"; //a
            /*********/
            string userId5 = "3BD94FC0-7656-4EC5-9C8F-90897DD64BE5";//s
            string userId6 = "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67"; //c
            string userId7 = "B9ECCC1E-FF12-41D0-9BE9-83B8A57EB855";//s
            string userId8 = "8CBAA357-F2D9-48FC-B4BC-27AD0BD7C1EB";// c
            string userId9 = "E403198E-3791-46B5-8A8E-81F469A5B48E";//s
            /***********/
            string ADMIN_ROLE_ID = "E2845098-5312-4925-94B7-2ED3664CA318";
            string STUDENT_ROLE_ID = "CB821695-B43A-41B9-8490-15A250D25FB5";
            string CONTRIBUTOR_ROLE_ID = "2C4560E3-B816-43E5-8DA9-15C94336DC72";

            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = userId1,
                    RoleId = CONTRIBUTOR_ROLE_ID
                },
                new IdentityUserRole<string>
                {
                    UserId = userId2,
                    RoleId = CONTRIBUTOR_ROLE_ID
                },
                new IdentityUserRole<string>
                {
                    UserId = userId3,
                    RoleId = STUDENT_ROLE_ID
                },
                new IdentityUserRole<string>
                {
                    UserId = userId4,
                    RoleId = ADMIN_ROLE_ID
                },
                new IdentityUserRole<string>
                {
                    UserId = userId5,
                    RoleId = STUDENT_ROLE_ID
                },
                new IdentityUserRole<string>
                {
                    UserId = userId6,
                    RoleId = CONTRIBUTOR_ROLE_ID
                },
                new IdentityUserRole<string>
                {
                    UserId = userId7,
                    RoleId = STUDENT_ROLE_ID
                },
                new IdentityUserRole<string>
                {
                    UserId = userId8,
                    RoleId = CONTRIBUTOR_ROLE_ID
                },
                new IdentityUserRole<string>
                {
                    UserId = userId9,
                    RoleId = STUDENT_ROLE_ID
                }
            );
        }
    }
}
