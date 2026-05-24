using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StuMap.Models;
using StuMap.Models.Enums;

namespace StuMap.DataSeeding
{
    public class IdentityUserSeedConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            string userId1 = "E2E368AB-8D20-401B-826A-F591202E3D19"; // c
            string userId2 = "E746D970-DB04-4D42-9493-9173C7D13EE9";  //c
            string userId3 = "B1364EFC-1779-4C6E-9623-0010F8F9EE89";
            string userId4 = "074B369D-5560-4ADA-99D2-F8AECF1E2423";
            /*********/
            string userId5 = "3BD94FC0-7656-4EC5-9C8F-90897DD64BE5";
            string userId6 = "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67"; //c
            string userId7 = "B9ECCC1E-FF12-41D0-9BE9-83B8A57EB855";
            string userId8 = "8CBAA357-F2D9-48FC-B4BC-27AD0BD7C1EB";// c
            string userId9 = "E403198E-3791-46B5-8A8E-81F469A5B48E";
   

            var user1 = new ApplicationUser
            {
             
                Id = userId1,
                UserName = "frankofoedu@contributor.com",
                FirstName= "Frank",
                LastName= "Sinatra",
                Country= "Egypt",
                DateOfBirth= DateTime.Parse("2001-05-17 03:29:48.8080706"),
                NormalizedUserName = "FRANKOFOEDU@CONTRIBUTOR.COM",
                Email = "frankofoedu@contributor.com",
                NormalizedEmail = "FRANKOFOEDU@CONTRIBUTOR.COM",
                LockoutEnabled = false,
                PasswordHash = "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==",
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
                SecurityStamp = userId1,
                ConcurrencyStamp = userId1,
                ContributorStatus = ContributorStatus.Approved,

            };

            var user2 = new ApplicationUser
            {
                Id = userId2,
                UserName = "amiraofoedu@contributor.com",
                FirstName = "Amira",
                LastName = "Abdelaziz",
                Country = "Egypt",
                DateOfBirth = DateTime.Parse("2001-05-17 03:29:48.8080706"),
                NormalizedUserName = "AMIRAOFOEDU@CONTRIBUTOR.COM",
                Email = "amiraofoedu@contributor.com",
                NormalizedEmail = "AMIRAOFOEDU@CONTRIBUTOR.COM",
                LockoutEnabled = false,
                PasswordHash = "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==",
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
                SecurityStamp = userId2,
                ConcurrencyStamp = userId2,
                   ContributorStatus = ContributorStatus.Approved,
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
                NormalizedUserName = "ADMIN@STUMAP.COM",
                Email = "admin@stumap.com",
                NormalizedEmail = "ADMIN@STUMAP.COM",
                PasswordHash = "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==",
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
                SecurityStamp = userId4,
                ConcurrencyStamp = userId4

            };

            /***************/
            var user5 = new ApplicationUser
            {
                Id = userId5,
                UserName = "ahmed@student.com",
                FirstName = "Ahmed",
                LastName = "Hassan",
                Country = "Egypt",
                DateOfBirth = new DateTime(2000, 5, 12),
                NormalizedUserName = "AHMED@STUDENT.COM",
                Email = "ahmed@student.com",
                NormalizedEmail = "AHMED@STUDENT.COM",
                LockoutEnabled = false,
                PasswordHash = "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==",
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
                SecurityStamp = userId5,
                ConcurrencyStamp = userId5
            };
            var user6 = new ApplicationUser
            {
                Id = userId6,
                UserName = "sara@contributor.com",
                FirstName = "Sara",
                LastName = "Ali",
                Country = "Egypt",
                DateOfBirth = new DateTime(1995, 3, 8),
                NormalizedUserName = "SARA@CONTRIBUTOR.COM",
                Email = "sara@contributor.com",
                NormalizedEmail = "SARA@CONTRIBUTOR.COM",
                ContributorStatus = ContributorStatus.Approved,
                LockoutEnabled = false,
                PasswordHash = "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==",
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
                SecurityStamp = userId6,
                ConcurrencyStamp = userId6

            };
            var user7 = new ApplicationUser
            {
                Id = userId7,
                UserName = "mohamed@student.com",
                FirstName = "Mohamed",
                LastName = "Ibrahim",
                Country = "Egypt",
                DateOfBirth = new DateTime(2001, 11, 20),
                NormalizedUserName = "MOHAMED@STUDENT.COM",
                Email = "mohamed@student.com",
                NormalizedEmail = "MOHAMED@STUDENT.COM",
                LockoutEnabled = false,
                PasswordHash = "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==",
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
                SecurityStamp = userId7,
                ConcurrencyStamp = userId7,
       
            };
            var user8 = new ApplicationUser
            {
                Id = userId8,
                UserName = "fatma@contributor.com",
                FirstName = "Fatma",
                LastName = "Youssef",
                Country = "Egypt",
                DateOfBirth = new DateTime(1993, 7, 15),
                NormalizedUserName = "FATMA@CONTRIBUTOR.COM",
                Email = "fatma@contributor.com",
                NormalizedEmail = "FATMA@CONTRIBUTOR.COM",
                IsContributorRequest = true,
                ContributorStatus = ContributorStatus.Pending,
                LockoutEnabled = false,
                PasswordHash = "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==",
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
                SecurityStamp = userId8,
                ConcurrencyStamp = userId8,

            };
            // … add 6 more users with a mix of students and contributors
            var user9 = new ApplicationUser
            {
                Id = userId9,
                UserName = "omar@student.com",
                FirstName = "Omar",
                LastName = "Khaled",
                Country = "Egypt",
                DateOfBirth = new DateTime(2002, 9, 2),
                NormalizedUserName = "OMAR@STUDENT.COM",
                Email = "omar@student.com",
                NormalizedEmail = "OMAR@STUDENT.COM",
                LockoutEnabled = false,
                PasswordHash = "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==",
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
                SecurityStamp = userId9,
                ConcurrencyStamp = userId9,

            };

            builder.HasData(
                user1,user2,user3,user4, user5, user6, user7, user8, user9
                );
        }
    }
}
