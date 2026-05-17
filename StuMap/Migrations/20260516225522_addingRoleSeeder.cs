using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StuMap.Migrations
{
    /// <inheritdoc />
    public partial class addingRoleSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2C4560E3-B816-43E5-8DA9-15C94336DC72", "2C4560E3-B816-43E5-8DA9-15C94336DC72", "Contributor", "CONTRIBUTOR" },
                    { "CB821695-B43A-41B9-8490-15A250D25FB5", "CB821695-B43A-41B9-8490-15A250D25FB5", "Student", "STUDENT" },
                    { "E2845098-5312-4925-94B7-2ED3664CA318", "E2845098-5312-4925-94B7-2ED3664CA318", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2C4560E3-B816-43E5-8DA9-15C94336DC72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "CB821695-B43A-41B9-8490-15A250D25FB5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "E2845098-5312-4925-94B7-2ED3664CA318");
        }
    }
}
