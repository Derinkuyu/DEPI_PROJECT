using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StuMap.Models;

namespace StuMap.DataSeeding
{
    public class CourseEnrollmentSeedConfiguration : IEntityTypeConfiguration<CourseEnrollment>
    {
        public void Configure(EntityTypeBuilder<CourseEnrollment> builder)
        {
            string userId3 = "B1364EFC-1779-4C6E-9623-0010F8F9EE89";

            /*********/
            string userId5 = "3BD94FC0-7656-4EC5-9C8F-90897DD64BE5";
            string userId7 = "B9ECCC1E-FF12-41D0-9BE9-83B8A57EB855";
            string userId9 = "E403198E-3791-46B5-8A8E-81F469A5B48E";


            builder.HasData(
                new CourseEnrollment
                {
                    StudentId = userId3,
                    CourseId = 1,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new CourseEnrollment
                {
                    StudentId = userId3,
                    CourseId = 2,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new CourseEnrollment
                {
                    StudentId = userId3,
                    CourseId = 3,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                  new CourseEnrollment
                  {
                      StudentId = userId5, 
                      CourseId = 1,
                      DateEnrolled = new DateTime(2026, 1, 15)
                  },
                new CourseEnrollment
                {
                    StudentId = userId5, 
                    CourseId = 2,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new CourseEnrollment
                {
                    StudentId = userId5,
                    CourseId = 3,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new CourseEnrollment
                {
                    StudentId = userId7,
                    CourseId = 4,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new CourseEnrollment
                {
                    StudentId = userId7,
                    CourseId = 5,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new CourseEnrollment
                {
                    StudentId = userId7,
                    CourseId = 6,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new CourseEnrollment
                {
                    StudentId = userId7,
                    CourseId = 7,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new CourseEnrollment
                {
                    StudentId = userId9,
                    CourseId = 8,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new CourseEnrollment
                {
                    StudentId = userId9,
                    CourseId = 9,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new CourseEnrollment
                {
                    StudentId = userId9,
                    CourseId = 10,
                    DateEnrolled = new DateTime(2026, 1, 15)
                }
                );
        }
    }
}
