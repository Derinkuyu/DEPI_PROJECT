using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StuMap.Migrations
{
    /// <inheritdoc />
    public partial class MaterialSeeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "ContributorId", "CourseId", "DateCreated", "Description", "IsApproved", "MaterialTypeId", "Title", "Url" },
                values: new object[,]
                {
                    { 1, "E2E368AB-8D20-401B-826A-F591202E3D19", 1, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "An authoritative, text-based guide by MDN Web Docs outlining elements, tags, attributes, and formatting requirements for standard web documents.", null, 1, "MDN Web Docs: Basic HTML Syntax", "https://developer.mozilla.org/en-US/docs/Learn_web_development/Core/Structuring_content/Basic_HTML_syntax" },
                    { 2, "E2E368AB-8D20-401B-826A-F591202E3D19", 1, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "An interactive web-based sandbox tool from W3Schools allowing you to write basic markup and instantly preview rendered headings, links, and text formatting.", null, 1, "W3Schools: HTML Tutorial", "https://www.w3schools.com/Html/" },
                    { 3, "E2E368AB-8D20-401B-826A-F591202E3D19", 1, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "A comprehensive, four-hour structural video layout tutorial hosted on YouTube via freeCodeCamp designed to advance beginners through core content tagging.", null, 3, "freeCodeCamp: Learn HTML Full Tutorial for Beginners", "https://www.youtube.com/watch?v=kUMe1FH4CHE" },
                    { 4, "E2E368AB-8D20-401B-826A-F591202E3D19", 2, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "A foundational guide on MDN Web Docs detailing cascade inheritance, standard syntax declarations, color applications, and fundamental font properties.", null, 1, "MDN Web Docs: CSS First Steps", "https://developer.mozilla.org/en-US/docs/Web/CSS" },
                    { 5, "E2E368AB-8D20-401B-826A-F591202E3D19", 2, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "A focused structural design video playlist from freeCodeCamp demonstrating visual layout selectors, custom borders, elements padding, and style rules.", null, 3, "freeCodeCamp: CSS Tutorial – Full Course for Beginners", "https://www.youtube.com/watch?v=OXGznpKZ_sA" },
                    { 6, "E2E368AB-8D20-401B-826A-F591202E3D19", 2, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "A modular web text environment via W3Schools with quick templates, text-align rules, custom backgrounds, and step-by-step styling exercises.", null, 1, "W3Schools: Online CSS Tutorials", "https://www.w3schools.com/css/" },
                    { 7, "E2E368AB-8D20-401B-826A-F591202E3D19", 3, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "An intensive project-based video on YouTube via SuperSimpleDev/freeCodeCamp mapping responsive website components and complex grid layouts.", null, 3, "freeCodeCamp: HTML & CSS Full Course - Beginner to Pro", "https://www.youtube.com/watch?v=G3e-cpL7ofc" },
                    { 8, "E2E368AB-8D20-401B-826A-F591202E3D19", 3, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "An instructional web framework guide by W3Schools showcasing dynamic viewport adjustments and screen-fluid grid column behaviors.", null, 1, "W3Schools: Build Responsive Sites with W3.CSS", "https://www.w3schools.com/css/" },
                    { 9, "E746D970-DB04-4D42-9493-9173C7D13EE9", 4, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "A technical deployment article from MDN Web Docs explaining script tag execution order, variable linkage, and element handling scripts.", null, 1, "MDN Web Docs: Adding JavaScript to an HTML File", "https://developer.mozilla.org/en-US/docs/Web/HTML" },
                    { 10, "E746D970-DB04-4D42-9493-9173C7D13EE9", 4, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "A comprehensive foundational video course on YouTube via freeCodeCamp exploring programmatic statements, custom functions, and interactive button bindings.", null, 3, "freeCodeCamp: Learn JavaScript Full Course for Beginners", "https://www.youtube.com/c/Freecodecamp" },
                    { 11, "E746D970-DB04-4D42-9493-9173C7D13EE9", 4, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "A live programming sandbox on W3Schools providing quick snippets to modify document style properties dynamically via user clicks.", null, 1, "W3Schools: JavaScript Interactive Reference", "https://www.w3schools.com/js/" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
