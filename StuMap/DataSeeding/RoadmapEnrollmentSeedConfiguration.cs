using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StuMap.Models;

namespace StuMap.DataSeeding
{
    public class RoadmapEnrollmentSeedConfiguration : IEntityTypeConfiguration<RoadmapEnrollment>
    {
        public void Configure(EntityTypeBuilder<RoadmapEnrollment> builder)
        {

//1 , 2 , 4 , 5  Approved roadmaps
            string userId3 = "B1364EFC-1779-4C6E-9623-0010F8F9EE89";

            /*********/
            string userId5 = "3BD94FC0-7656-4EC5-9C8F-90897DD64BE5";
            string userId7 = "B9ECCC1E-FF12-41D0-9BE9-83B8A57EB855";
            string userId9 = "E403198E-3791-46B5-8A8E-81F469A5B48E";

            builder.HasData(
                new RoadmapEnrollment
                {
                    StudentId = userId3, 
                    RoadmapId = 1,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new RoadmapEnrollment
                {
                    StudentId = userId3, 
                    RoadmapId = 2,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new RoadmapEnrollment
                {
                    StudentId = userId3,
                    RoadmapId = 4,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new RoadmapEnrollment
                {
                    StudentId = userId3,
                    RoadmapId = 5,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new RoadmapEnrollment
                {
                    StudentId = userId5,
                    RoadmapId = 1,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new RoadmapEnrollment
                {
                    StudentId = userId5,
                    RoadmapId = 2,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new RoadmapEnrollment
                {
                    StudentId = userId5,
                    RoadmapId = 4,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new RoadmapEnrollment
                {
                    StudentId = userId5,
                    RoadmapId = 5,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new RoadmapEnrollment
                {
                    StudentId = userId7,
                    RoadmapId = 1,
                    DateEnrolled = new DateTime(2026, 1, 15)
                },
                new RoadmapEnrollment
                {
                    StudentId = userId9,
                    RoadmapId = 2,
                    DateEnrolled = new DateTime(2026, 1, 15)
                }
        );
        }
    }
}
