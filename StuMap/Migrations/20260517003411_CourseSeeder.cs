using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StuMap.Migrations
{
    /// <inheritdoc />
    public partial class CourseSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "ContributorId", "DateCreated", "Description", "IsApproved", "RoadmapId", "Title" },
                values: new object[,]
                {
                    { 1, "E2E368AB-8D20-401B-826A-F591202E3D19", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Learn the absolute basics of building web pages. Master the structure of a website using text elements, hyperlinks, forms, images, and semantic tags that help search engines understand your content.", null, null, "Introduction to HTML5" },
                    { 2, "E2E368AB-8D20-401B-826A-F591202E3D19", new DateTime(2026, 5, 16, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Transform plain text into beautiful, styled web pages. Discover colors, custom fonts, borders, margins, padding, and how to use selectors to target and style specific elements across your site.", null, null, "Introduction to CSS3" },
                    { 3, "E2E368AB-8D20-401B-826A-F591202E3D19", new DateTime(2026, 5, 15, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Learn how to make your websites look perfect on any screen size. Master modern layouts using CSS Flexbox and Grid, and use media queries to automatically adapt designs for mobile phones, tablets, and desktops.", null, null, "Creating Responsive Web Designs" },
                    { 4, "E746D970-DB04-4D42-9493-9173C7D13EE9", new DateTime(2026, 5, 14, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Bring your static web pages to life with interactivity. Learn the fundamentals of programming—like variables, functions, and events—to handle user clicks, toggle menus, and create dynamic content.", null, null, "Basic JavaScript for the Web" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
