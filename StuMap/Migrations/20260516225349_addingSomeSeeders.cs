using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StuMap.Migrations
{
    /// <inheritdoc />
    public partial class addingSomeSeeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoadmapId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "074B369D-5560-4ADA-99D2-F8AECF1E2423", 0, "074B369D-5560-4ADA-99D2-F8AECF1E2423", "aadmin@stumap.com", true, false, null, "AADMIN@STUMAP.COM", "AADMIN@STUMAP.COM", "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==", "1234567890", false, null, "074B369D-5560-4ADA-99D2-F8AECF1E2423", false, "aadmin@stumap.com" },
                    { "B1364EFC-1779-4C6E-9623-0010F8F9EE89", 0, "B1364EFC-1779-4C6E-9623-0010F8F9EE89", "faridaofoedu@gmail.com", true, false, null, "FARIDAOFOEDU@GMAIL.COM", "FARIDA", "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==", "1234567890", false, null, "B1364EFC-1779-4C6E-9623-0010F8F9EE89", false, "Farida" },
                    { "E2E368AB-8D20-401B-826A-F591202E3D19", 0, "E2E368AB-8D20-401B-826A-F591202E3D19", "frankofoedu@gmail.com", true, false, null, "FRANKOFOEDU@GMAIL.COM", "FRANK", "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==", "1234567890", false, null, "E2E368AB-8D20-401B-826A-F591202E3D19", false, "Frank" },
                    { "E746D970-DB04-4D42-9493-9173C7D13EE9", 0, "E746D970-DB04-4D42-9493-9173C7D13EE9", "amiraofoedu@gmail.com", true, false, null, "AMIRAOFOEDU@GMAIL.COM", "AMIRA", "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==", "1234567890", false, null, "E746D970-DB04-4D42-9493-9173C7D13EE9", false, "Amira" }
                });

            migrationBuilder.InsertData(
                table: "MaterialTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Article" },
                    { 2, "Paper" },
                    { 3, "Video" },
                    { 4, "Image" },
                    { 5, "Book" },
                    { 6, "Exam" },
                    { 7, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Computer Science studies how computers work, focusing on algorithms, data, and problem‑solving. It blends theory and practice to build systems like AI, databases, and operating systems.", "Computer Science" },
                    { 2, "Information Technology applies computer systems to manage and secure data. It covers networks, servers, and user support, ensuring organizations run smoothly with reliable tech.", "Information Technology" },
                    { 3, "Software Engineering designs and builds software using structured methods. It emphasizes quality, scalability, and teamwork across the full lifecycle—from planning to maintenance.", "Software Engineering" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "074B369D-5560-4ADA-99D2-F8AECF1E2423");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B1364EFC-1779-4C6E-9623-0010F8F9EE89");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E2E368AB-8D20-401B-826A-F591202E3D19");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E746D970-DB04-4D42-9493-9173C7D13EE9");

            migrationBuilder.DeleteData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
