using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StuMap.DAL.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsContributorRequest = table.Column<bool>(type: "bit", nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContributorStatus = table.Column<int>(type: "int", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificatePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoadmapId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContributorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateIssued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_AspNetUsers_ContributorId",
                        column: x => x.ContributorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DateSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AdminReply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepliedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContributorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_AspNetUsers_ContributorId",
                        column: x => x.ContributorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Roadmaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContributorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SpecializationId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roadmaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roadmaps_AspNetUsers_ContributorId",
                        column: x => x.ContributorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Roadmaps_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseEnrollments",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    DateEnrolled = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEnrollments", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_CourseEnrollments_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEnrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialTypeId = table.Column<int>(type: "int", nullable: false),
                    ContributorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_AspNetUsers_ContributorId",
                        column: x => x.ContributorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Materials_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materials_MaterialTypes_MaterialTypeId",
                        column: x => x.MaterialTypeId,
                        principalTable: "MaterialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseRoadmap",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    RoadmapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRoadmap", x => new { x.CoursesId, x.RoadmapId });
                    table.ForeignKey(
                        name: "FK_CourseRoadmap_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseRoadmap_Roadmaps_RoadmapId",
                        column: x => x.RoadmapId,
                        principalTable: "Roadmaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoadmapEnrollment",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoadmapId = table.Column<int>(type: "int", nullable: false),
                    DateEnrolled = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadmapEnrollment", x => new { x.RoadmapId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_RoadmapEnrollment_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoadmapEnrollment_Roadmaps_RoadmapId",
                        column: x => x.RoadmapId,
                        principalTable: "Roadmaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoadmapsProgresses",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoadmapId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    RoadmapEnrollmentRoadmapId = table.Column<int>(type: "int", nullable: true),
                    RoadmapEnrollmentStudentId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadmapsProgresses", x => new { x.RoadmapId, x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_RoadmapsProgresses_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoadmapsProgresses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoadmapsProgresses_RoadmapEnrollment_RoadmapEnrollmentRoadmapId_RoadmapEnrollmentStudentId",
                        columns: x => new { x.RoadmapEnrollmentRoadmapId, x.RoadmapEnrollmentStudentId },
                        principalTable: "RoadmapEnrollment",
                        principalColumns: new[] { "RoadmapId", "StudentId" });
                    table.ForeignKey(
                        name: "FK_RoadmapsProgresses_Roadmaps_RoadmapId",
                        column: x => x.RoadmapId,
                        principalTable: "Roadmaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2C4560E3-B816-43E5-8DA9-15C94336DC72", "2C4560E3-B816-43E5-8DA9-15C94336DC72", "Contributor", "CONTRIBUTOR" },
                    { "CB821695-B43A-41B9-8490-15A250D25FB5", "CB821695-B43A-41B9-8490-15A250D25FB5", "Student", "STUDENT" },
                    { "E2845098-5312-4925-94B7-2ED3664CA318", "E2845098-5312-4925-94B7-2ED3664CA318", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CertificatePath", "ConcurrencyStamp", "ContributorStatus", "Country", "CreatedAt", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "IsBlocked", "IsContributorRequest", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RejectionReason", "RequestDate", "RoadmapId", "SecurityStamp", "Specialization", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "074B369D-5560-4ADA-99D2-F8AECF1E2423", 0, null, "074B369D-5560-4ADA-99D2-F8AECF1E2423", 2, "Egypt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "aadmin@stumap.com", true, "admin", false, true, "admin", false, null, "AADMIN@STUMAP.COM", "AADMIN@STUMAP.COM", "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==", "1234567890", false, null, null, null, "074B369D-5560-4ADA-99D2-F8AECF1E2423", null, false, "admin@stumap.com" },
                    { "3BD94FC0-7656-4EC5-9C8F-90897DD64BE5", 0, null, "3BD94FC0-7656-4EC5-9C8F-90897DD64BE5", 2, "Egypt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed@student.com", true, "Ahmed", false, true, "Hassan", false, null, "AHMED@STUDENT.COM", "AHMED@STUDENT.COM", "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==", "1234567890", false, null, null, null, "3BD94FC0-7656-4EC5-9C8F-90897DD64BE5", null, false, "ahmed@student.com" },
                    { "8CBAA357-F2D9-48FC-B4BC-27AD0BD7C1EB", 0, null, "8CBAA357-F2D9-48FC-B4BC-27AD0BD7C1EB", 2, "Egypt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1993, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "fatma@contributor.com", true, "Fatma", false, true, "Youssef", false, null, "FATMA@CONTRIBUTOR.COM", "FATMA@CONTRIBUTOR.COM", "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==", "1234567890", false, null, null, null, "8CBAA357-F2D9-48FC-B4BC-27AD0BD7C1EB", null, false, "fatma@contributor.com" },
                    { "B1364EFC-1779-4C6E-9623-0010F8F9EE89", 0, null, "B1364EFC-1779-4C6E-9623-0010F8F9EE89", 2, "Egypt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "faridaofoedu@gmail.com", true, "Farida", false, true, "Mohammed", false, null, "FARIDAOFOEDU@GMAIL.COM", "FARIDAOFOEDU@GMAIL.COM", "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==", "1234567890", false, null, null, null, "B1364EFC-1779-4C6E-9623-0010F8F9EE89", null, false, "faridaofoedu@gmail.com" },
                    { "B9ECCC1E-FF12-41D0-9BE9-83B8A57EB855", 0, null, "B9ECCC1E-FF12-41D0-9BE9-83B8A57EB855", 2, "Egypt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mohamed@student.com", true, "Mohamed", false, true, "Ibrahim", false, null, "MOHAMED@STUDENT.COM", "MOHAMED@STUDENT.COM", "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==", "1234567890", false, null, null, null, "B9ECCC1E-FF12-41D0-9BE9-83B8A57EB855", null, false, "mohamed@student.com" },
                    { "E2E368AB-8D20-401B-826A-F591202E3D19", 0, null, "E2E368AB-8D20-401B-826A-F591202E3D19", 1, "Egypt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "frankofoedu@contributor.com", true, "Frank", false, true, "Sinatra", false, null, "FRANKOFOEDU@CONTRIBUTOR.COM", "FRANKOFOEDU@CONTRIBUTOR.COM", "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==", "1234567890", false, null, null, null, "E2E368AB-8D20-401B-826A-F591202E3D19", null, false, "frankofoedu@contributor.com" },
                    { "E403198E-3791-46B5-8A8E-81F469A5B48E", 0, null, "E403198E-3791-46B5-8A8E-81F469A5B48E", 2, "Egypt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2002, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar@student.com", true, "Omar", false, true, "Khaled", false, null, "OMAR@STUDENT.COM", "OMAR@STUDENT.COM", "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==", "1234567890", false, null, null, null, "E403198E-3791-46B5-8A8E-81F469A5B48E", null, false, "omar@student.com" },
                    { "E746D970-DB04-4D42-9493-9173C7D13EE9", 0, null, "E746D970-DB04-4D42-9493-9173C7D13EE9", 1, "Egypt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "amiraofoedu@contributor.com", true, "Amira", false, true, "Abdelaziz", false, null, "AMIRAOFOEDU@CONTRIBUTOR.COM", "AMIRAOFOEDU@CONTRIBUTOR.COM", "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==", "1234567890", false, null, null, null, "E746D970-DB04-4D42-9493-9173C7D13EE9", null, false, "amiraofoedu@contributor.com" },
                    { "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", 0, null, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", 1, "Egypt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara@contributor.com", true, "Sara", false, true, "Ali", false, null, "SARA@CONTRIBUTOR.COM", "SARA@CONTRIBUTOR.COM", "AQAAAAIAAYagAAAAEA1b94YdrgyUp6jDbQIM64vRSTjw7ojIiEqwPxWnXW5jegZQlfGGUF7/OgiO1Z0Lzw==", "1234567890", false, null, null, null, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", null, false, "sara@contributor.com" }
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
                    { 1, "Frontend and backend web technologies.", "Web Development" },
                    { 2, "Machine learning, statistics, and data analysis.", "Data Science" },
                    { 3, "Protecting systems, networks, and data.", "Cybersecurity" },
                    { 4, "Building apps for Android and iOS.", "Mobile Development" },
                    { 5, "AWS, Azure, and cloud-native architectures.", "Cloud Computing" },
                    { 6, "Deep learning, NLP, and intelligent systems.", "Artificial Intelligence" },
                    { 7, "Manual and automated testing practices.", "Software Testing" },
                    { 8, "CI/CD pipelines, containerization, and automation.", "DevOps" },
                    { 9, "Designing and programming interactive games.", "Game Development" },
                    { 10, "Computer networks, protocols, and CCNA fundamentals.", "Networking" }
                });

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

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "Approved", "ContributorId", "DateIssued", "Title", "Url" },
                values: new object[,]
                {
                    { 1, true, "E2E368AB-8D20-401B-826A-F591202E3D19", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Frontend Development Certificate", "https://example.com/certificates/frontend" },
                    { 2, true, "E746D970-DB04-4D42-9493-9173C7D13EE9", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Data Science Certificate", "https://example.com/certificates/datascience" },
                    { 3, true, "E746D970-DB04-4D42-9493-9173C7D13EE9", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Cybersecurity Fundamentals", "https://example.com/certificates/cybersecurity" },
                    { 4, true, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Mobile App Development", "https://example.com/certificates/mobile" },
                    { 5, true, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Cloud Computing with Azure", "https://example.com/certificates/cloud" },
                    { 6, true, "E746D970-DB04-4D42-9493-9173C7D13EE9", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Artificial Intelligence", "https://example.com/certificates/ai" },
                    { 8, true, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "DevOps Practices", "https://example.com/certificates/devops" },
                    { 9, true, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Game Development with Unity", "https://example.com/certificates/game" },
                    { 10, true, "E746D970-DB04-4D42-9493-9173C7D13EE9", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Networking Essentials", "https://example.com/certificates/networking" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "AdminReply", "Body", "DateSent", "IsRead", "RejectionReason", "RepliedAt", "Status", "Subject", "UserId" },
                values: new object[,]
                {
                    { 1, null, "I am having trouble understanding the material in the course.", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), false, null, null, 2, "Issue with course content", "B1364EFC-1779-4C6E-9623-0010F8F9EE89" },
                    { 2, null, "I would like to see a dark mode option in the app.", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), false, null, null, 0, "Feature request", "B1364EFC-1779-4C6E-9623-0010F8F9EE89" },
                    { 3, null, "The app crashes when I try to access my profile.", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), false, null, null, 1, "Bug report", "B1364EFC-1779-4C6E-9623-0010F8F9EE89" },
                    { 4, null, "I can not accesss my saved Roadmaps.", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), false, null, null, 1, "Access Roadmap", "B1364EFC-1779-4C6E-9623-0010F8F9EE89" },
                    { 5, null, "I am having trouble understanding the material in the course.", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), false, null, null, 2, "Issue with course content", "B1364EFC-1779-4C6E-9623-0010F8F9EE89" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "ApprovedAt", "ContributorId", "DateCreated", "Description", "IsDeleted", "LastUpdatedAt", "RejectionReason", "Status", "SubmittedAt", "Title" },
                values: new object[,]
                {
                    { 1, null, "E2E368AB-8D20-401B-826A-F591202E3D19", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Learn the absolute basics of building web pages. Master the structure of a website using text elements, hyperlinks, forms, images, and semantic tags that help search engines understand your content.", false, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introduction to HTML5" },
                    { 2, null, "E2E368AB-8D20-401B-826A-F591202E3D19", new DateTime(2026, 5, 16, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Transform plain text into beautiful, styled web pages. Discover colors, custom fonts, borders, margins, padding, and how to use selectors to target and style specific elements across your site.", false, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introduction to CSS3" },
                    { 3, null, "E2E368AB-8D20-401B-826A-F591202E3D19", new DateTime(2026, 5, 15, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Learn how to make your websites look perfect on any screen size. Master modern layouts using CSS Flexbox and Grid, and use media queries to automatically adapt designs for mobile phones, tablets, and desktops.", false, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Creating Responsive Web Designs" },
                    { 4, null, "E746D970-DB04-4D42-9493-9173C7D13EE9", new DateTime(2026, 5, 14, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Bring your static web pages to life with interactivity. Learn the fundamentals of programming—like variables, functions, and events—to handle user clicks, toggle menus, and create dynamic content.", false, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic JavaScript for the Web" },
                    { 5, null, "E746D970-DB04-4D42-9493-9173C7D13EE9", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Learn Python basics, NumPy, and Pandas.", false, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Python for Data Science" },
                    { 6, null, "E746D970-DB04-4D42-9493-9173C7D13EE9", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Supervised and unsupervised learning algorithms.", false, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Machine Learning Basics" },
                    { 7, null, "E746D970-DB04-4D42-9493-9173C7D13EE9", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Network security, encryption, and ethical hacking.", false, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cybersecurity Fundamentals" },
                    { 8, null, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Cross-platform mobile apps using Flutter and Dart.", false, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile App Development with Flutter" },
                    { 9, null, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Learn Azure fundamentals and cloud-native services.", false, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cloud Computing with Azure" },
                    { 10, null, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Containerization, orchestration, and CI/CD pipelines.", false, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DevOps with Docker & Kubernetes" },
                    { 11, null, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Learn Unity basics and build interactive games.", false, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game Development with Unity" },
                    { 12, null, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Learn basics of network and Its layers", false, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Network Essentials" }
                });

            migrationBuilder.InsertData(
                table: "Roadmaps",
                columns: new[] { "Id", "ApprovedAt", "ContributorId", "DateCreated", "Description", "IsApproved", "IsDeleted", "RejectionReason", "SpecializationId", "Status", "SubmittedAt", "Title" },
                values: new object[,]
                {
                    { 1, null, "E2E368AB-8D20-401B-826A-F591202E3D19", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Web development is the process of designing, building, and maintaining websites and web applications, combining both creative design and technical programming to deliver functional, user-friendly digital experiences. It includes front-end (what users see), back-end (server, database, logic), and full-stack (both sides) development", false, false, null, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web development" },
                    { 2, null, "E2E368AB-8D20-401B-826A-F591202E3D19", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Frontend development focuses on everything the user sees and interacts with in the browser. It’s about turning design mockups (like the Figma prototype you have open) into functional, responsive, and engaging web pages.", false, false, null, 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frontend Path" },
                    { 3, null, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Step-by-step guide to becoming a frontend developer.", false, false, null, 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frontend Development Roadmap" },
                    { 4, null, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Learn Python, statistics, and machine learning basics.", false, false, null, 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Data Science Beginner Roadmap" },
                    { 5, null, "E746D970-DB04-4D42-9493-9173C7D13EE9", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Introduction to network security and ethical hacking.", true, false, null, 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cybersecurity Essentials" },
                    { 6, null, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Learn Android and iOS development fundamentals.", false, false, null, 4, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile App Development Roadmap" }
                });

            migrationBuilder.InsertData(
                table: "CourseEnrollments",
                columns: new[] { "CourseId", "StudentId", "DateEnrolled" },
                values: new object[,]
                {
                    { 1, "B1364EFC-1779-4C6E-9623-0010F8F9EE89", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "B1364EFC-1779-4C6E-9623-0010F8F9EE89", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "B1364EFC-1779-4C6E-9623-0010F8F9EE89", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CourseRoadmap",
                columns: new[] { "CoursesId", "RoadmapId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 6 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 6 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 6 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 6 },
                    { 5, 4 },
                    { 6, 4 },
                    { 7, 5 },
                    { 8, 6 },
                    { 12, 5 }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "ContributorId", "CourseId", "DateCreated", "Description", "MaterialTypeId", "Title", "Url" },
                values: new object[,]
                {
                    { 1, "E2E368AB-8D20-401B-826A-F591202E3D19", 1, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "An authoritative, text-based guide by MDN Web Docs outlining elements, tags, attributes, and formatting requirements for standard web documents.", 1, "MDN Web Docs: Basic HTML Syntax", "https://developer.mozilla.org/en-US/docs/Learn_web_development/Core/Structuring_content/Basic_HTML_syntax" },
                    { 2, "E2E368AB-8D20-401B-826A-F591202E3D19", 1, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "An interactive web-based sandbox tool from W3Schools allowing you to write basic markup and instantly preview rendered headings, links, and text formatting.", 1, "W3Schools: HTML Tutorial", "https://www.w3schools.com/Html/" },
                    { 3, "E2E368AB-8D20-401B-826A-F591202E3D19", 1, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "A comprehensive, four-hour structural video layout tutorial hosted on YouTube via freeCodeCamp designed to advance beginners through core content tagging.", 3, "freeCodeCamp: Learn HTML Full Tutorial for Beginners", "https://www.youtube.com/watch?v=kUMe1FH4CHE" },
                    { 4, "E2E368AB-8D20-401B-826A-F591202E3D19", 2, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "A foundational guide on MDN Web Docs detailing cascade inheritance, standard syntax declarations, color applications, and fundamental font properties.", 1, "MDN Web Docs: CSS First Steps", "https://developer.mozilla.org/en-US/docs/Web/CSS" },
                    { 5, "E2E368AB-8D20-401B-826A-F591202E3D19", 2, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "A focused structural design video playlist from freeCodeCamp demonstrating visual layout selectors, custom borders, elements padding, and style rules.", 3, "freeCodeCamp: CSS Tutorial – Full Course for Beginners", "https://www.youtube.com/watch?v=OXGznpKZ_sA" },
                    { 6, "E2E368AB-8D20-401B-826A-F591202E3D19", 2, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "A modular web text environment via W3Schools with quick templates, text-align rules, custom backgrounds, and step-by-step styling exercises.", 1, "W3Schools: Online CSS Tutorials", "https://www.w3schools.com/css/" },
                    { 7, "E2E368AB-8D20-401B-826A-F591202E3D19", 3, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "An intensive project-based video on YouTube via SuperSimpleDev/freeCodeCamp mapping responsive website components and complex grid layouts.", 3, "freeCodeCamp: HTML & CSS Full Course - Beginner to Pro", "https://www.youtube.com/watch?v=G3e-cpL7ofc" },
                    { 8, "E2E368AB-8D20-401B-826A-F591202E3D19", 3, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "An instructional web framework guide by W3Schools showcasing dynamic viewport adjustments and screen-fluid grid column behaviors.", 1, "W3Schools: Build Responsive Sites with W3.CSS", "https://www.w3schools.com/css/" },
                    { 9, "E746D970-DB04-4D42-9493-9173C7D13EE9", 4, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "A technical deployment article from MDN Web Docs explaining script tag execution order, variable linkage, and element handling scripts.", 1, "MDN Web Docs: Adding JavaScript to an HTML File", "https://developer.mozilla.org/en-US/docs/Web/HTML" },
                    { 10, "E746D970-DB04-4D42-9493-9173C7D13EE9", 4, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "A comprehensive foundational video course on YouTube via freeCodeCamp exploring programmatic statements, custom functions, and interactive button bindings.", 3, "freeCodeCamp: Learn JavaScript Full Course for Beginners", "https://www.youtube.com/c/Freecodecamp" },
                    { 11, "E746D970-DB04-4D42-9493-9173C7D13EE9", 4, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "A live programming sandbox on W3Schools providing quick snippets to modify document style properties dynamically via user clicks.", 1, "W3Schools: JavaScript Interactive Reference", "https://www.w3schools.com/js/" },
                    { 12, "E2E368AB-8D20-401B-826A-F591202E3D19", 1, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Introduction to HTML tags and structure.", 1, "HTML Basics Article", "https://example.com/html-basics" },
                    { 13, "E2E368AB-8D20-401B-826A-F591202E3D19", 2, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Learn how to use flexbox for layouts.", 2, "CSS Flexbox Video", "https://example.com/css-flexbox-video" },
                    { 14, "E746D970-DB04-4D42-9493-9173C7D13EE9", 4, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Comprehensive guide to JavaScript basics.", 3, "JavaScript Fundamentals Book", "https://example.com/js-fundamentals-book" },
                    { 15, "E746D970-DB04-4D42-9493-9173C7D13EE9", 4, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Hands-on tutorial for Python data analysis.", 1, "Python for Data Science Tutorial", "https://example.com/python-data-science" },
                    { 16, "E746D970-DB04-4D42-9493-9173C7D13EE9", 6, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Exploring supervised learning algorithms.", 6, "Machine Learning Research Paper", "https://example.com/ml-research-paper" },
                    { 17, "E746D970-DB04-4D42-9493-9173C7D13EE9", 7, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Test your knowledge of cybersecurity basics.", 6, "Cybersecurity Fundamentals Exam", "https://example.com/cybersecurity-exam" },
                    { 18, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", 8, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Build cross-platform apps with Flutter.", 3, "Flutter Mobile Development Video", "https://example.com/flutter-video" },
                    { 19, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", 9, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Overview of Azure cloud services.", 1, "Azure Cloud Presentation", "https://example.com/azure-presentation" },
                    { 20, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", 10, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Discussion on containerization and orchestration.", 3, "Docker & Kubernetes Podcast", "https://example.com/devops-podcast" },
                    { 21, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", 11, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Visual guide to Unity interface.", 4, "Unity Game Development Image", "https://example.com/unity-image" },
                    { 22, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", 12, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Explore all Network Types And learn How it works", 4, "Network Types", "https://example.com/network-types" },
                    { 23, "EF8CCDB4-F6F5-4A89-BF18-E6E063271F67", 12, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Explore all Network Layers And learn How it works", 4, "Network Layers", "https://example.com/network-Layers" },
                    { 24, "E746D970-DB04-4D42-9493-9173C7D13EE9", 5, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "python guide for beginners", 4, "Python basics", "https://example.com/Python-basics" },
                    { 25, "E746D970-DB04-4D42-9493-9173C7D13EE9", 5, new DateTime(2026, 5, 17, 3, 29, 48, 808, DateTimeKind.Unspecified).AddTicks(706), "Learn how to use NumPy in Python", 4, "NumPy Library in Python", "https://example.com/Numpy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoadmapId",
                table: "AspNetUsers",
                column: "RoadmapId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_ContributorId",
                table: "Certificates",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollments_StudentId",
                table: "CourseEnrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRoadmap_RoadmapId",
                table: "CourseRoadmap",
                column: "RoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ContributorId",
                table: "Courses",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ContributorId",
                table: "Materials",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CourseId",
                table: "Materials",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialTypeId",
                table: "Materials",
                column: "MaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadmapEnrollment_StudentId",
                table: "RoadmapEnrollment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Roadmaps_ContributorId",
                table: "Roadmaps",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_Roadmaps_SpecializationId",
                table: "Roadmaps",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadmapsProgresses_CourseId",
                table: "RoadmapsProgresses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadmapsProgresses_RoadmapEnrollmentRoadmapId_RoadmapEnrollmentStudentId",
                table: "RoadmapsProgresses",
                columns: new[] { "RoadmapEnrollmentRoadmapId", "RoadmapEnrollmentStudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoadmapsProgresses_StudentId",
                table: "RoadmapsProgresses",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Roadmaps_RoadmapId",
                table: "AspNetUsers",
                column: "RoadmapId",
                principalTable: "Roadmaps",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roadmaps_AspNetUsers_ContributorId",
                table: "Roadmaps");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "CourseEnrollments");

            migrationBuilder.DropTable(
                name: "CourseRoadmap");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "RoadmapsProgresses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "MaterialTypes");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "RoadmapEnrollment");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Roadmaps");

            migrationBuilder.DropTable(
                name: "Specializations");
        }
    }
}
