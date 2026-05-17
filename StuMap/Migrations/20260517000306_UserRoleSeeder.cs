using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StuMap.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "E2845098-5312-4925-94B7-2ED3664CA318", "074B369D-5560-4ADA-99D2-F8AECF1E2423" },
                    { "CB821695-B43A-41B9-8490-15A250D25FB5", "B1364EFC-1779-4C6E-9623-0010F8F9EE89" },
                    { "2C4560E3-B816-43E5-8DA9-15C94336DC72", "E2E368AB-8D20-401B-826A-F591202E3D19" },
                    { "2C4560E3-B816-43E5-8DA9-15C94336DC72", "E746D970-DB04-4D42-9493-9173C7D13EE9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "E2845098-5312-4925-94B7-2ED3664CA318", "074B369D-5560-4ADA-99D2-F8AECF1E2423" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "CB821695-B43A-41B9-8490-15A250D25FB5", "B1364EFC-1779-4C6E-9623-0010F8F9EE89" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2C4560E3-B816-43E5-8DA9-15C94336DC72", "E2E368AB-8D20-401B-826A-F591202E3D19" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2C4560E3-B816-43E5-8DA9-15C94336DC72", "E746D970-DB04-4D42-9493-9173C7D13EE9" });
        }
    }
}
