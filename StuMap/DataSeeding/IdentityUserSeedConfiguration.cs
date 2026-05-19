using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StuMap.Models;

namespace StuMap.DataSeeding
{
    public class IdentityUserSeedConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            string userId1 = "E2E368AB-8D20-401B-826A-F591202E3D19";
            string userId2 = "E746D970-DB04-4D42-9493-9173C7D13EE9";
            string userId3 = "B1364EFC-1779-4C6E-9623-0010F8F9EE89";
            string userId4 = "074B369D-5560-4ADA-99D2-F8AECF1E2423";

            var user1 = new ApplicationUser
            {
             
                Id = userId1,
                UserName = "frankofoedu@gmail.com",
                FirstName= "Frank",
                LastName= "Sinatra",
                Country= "Egypt",
                DateOfBirth= DateTime.Parse("2001-05-17 03:29:48.8080706"),
                NormalizedUserName = "FRANKOFOEDU@GMAIL.COM",
                Email = "frankofoedu@gmail.com",
                NormalizedEmail = "FRANKOFOEDU@GMAIL.COM",
                LockoutEnabled = false,
                PasswordHash = "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==",
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
                SecurityStamp = userId1,
                ConcurrencyStamp = userId1

            };

            var user2 = new ApplicationUser
            {
                Id = userId2,
                UserName = "amiraofoedu@gmail.com",
                FirstName = "Amira",
                LastName = "Abdelaziz",
                Country = "Egypt",
                DateOfBirth = DateTime.Parse("2001-05-17 03:29:48.8080706"),
                NormalizedUserName = "AMIRAOFOEDU@GMAIL.COM",
                Email = "amiraofoedu@gmail.com",
                NormalizedEmail = "AMIRAOFOEDU@GMAIL.COM",
                LockoutEnabled = false,
                PasswordHash = "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==",
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
                SecurityStamp = userId2,
                ConcurrencyStamp = userId2
            };

            var user3 = new ApplicationUser
            {
                Id = userId3,
                UserName = "faridaofoedu@gmail.com",
                FirstName = "Farida",
                LastName = "Mohammed",
                Country = "Egypt",
                DateOfBirth = DateTime.Parse("2001-05-17 03:29:48.8080706"),
                NormalizedUserName = "FARIDAOFOEDU@GMAIL.COM",
                Email = "faridaofoedu@gmail.com",
                NormalizedEmail = "FARIDAOFOEDU@GMAIL.COM",
                LockoutEnabled = false,
                PasswordHash = "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==",
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
                SecurityStamp = userId3,
                ConcurrencyStamp = userId3
            };

            var user4 = new ApplicationUser
            {
                Id = userId4,
                UserName = "admin@stumap.com",
                FirstName = "admin",
                LastName = "admin",
                Country = "Egypt",
                DateOfBirth = DateTime.Parse("2001-05-17 03:29:48.8080706"),
                NormalizedUserName = "AADMIN@STUMAP.COM",
                Email = "aadmin@stumap.com",
                NormalizedEmail = "AADMIN@STUMAP.COM",
                PasswordHash = "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==",
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
                SecurityStamp = userId4,
                ConcurrencyStamp = userId4

            };
            builder.HasData(
                user1,user2,user3,user4
                );
        }
    }
}
