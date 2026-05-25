using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StuMap.DAL.Models;

namespace StuMap.DAL.DataSeeding
{
    public class CourseEnrollmentSeedConfiguration : IEntityTypeConfiguration<CourseEnrollment>
    {
        public void Configure(EntityTypeBuilder<CourseEnrollment> builder)
        {
            string STUDENT_ID = "B1364EFC-1779-4C6E-9623-0010F8F9EE89";

            builder.HasData(
                new CourseEnrollment
                {
                    StudentId = STUDENT_ID,
                    CourseId = 1,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new CourseEnrollment
                {
                    StudentId = STUDENT_ID,
                    CourseId = 2,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new CourseEnrollment
                {
                    StudentId = STUDENT_ID,
                    CourseId = 3,
                    DateEnrolled = new DateTime(2026, 1, 15)
                }
                );
        }
    }
}
