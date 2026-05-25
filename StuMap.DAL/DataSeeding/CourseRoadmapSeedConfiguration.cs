using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StuMap.DAL.Models;

namespace StuMap.DAL.DataSeeding
{
    public class CourseRoadmapSeedConfiguration : IEntityTypeConfiguration<CourseRoadmap>

    {
        public void Configure(EntityTypeBuilder<CourseRoadmap> builder)
        {
            // Seed data for  entity
            builder.HasData(
                new CourseRoadmap
                {
                    RoadmapId = 1,
                    CoursesId = 1
                },
                new CourseRoadmap
                {
                    RoadmapId = 1,
                    CoursesId = 2
                },
                new CourseRoadmap
                {
                    RoadmapId = 1,
                    CoursesId = 3
                },
                new CourseRoadmap
                {
                    RoadmapId = 1,
                    CoursesId = 4
                },
                new CourseRoadmap
                {
                    RoadmapId = 2,
                    CoursesId = 1
                },
                new CourseRoadmap
                {
                    RoadmapId = 2,
                    CoursesId = 2
                },
                new CourseRoadmap
                {
                    RoadmapId = 2,
                    CoursesId = 3
                },
                new CourseRoadmap
                {
                    RoadmapId = 2,
                    CoursesId = 4
                },
                 new CourseRoadmap
                 {
                     RoadmapId = 4,
                     CoursesId = 5
                 },
                 new CourseRoadmap
                 {
                     RoadmapId = 4,
                     CoursesId = 6
                 },
                 new CourseRoadmap
                 {
                     RoadmapId = 5,
                     CoursesId = 12
                 },
                 new CourseRoadmap
                 {
                     RoadmapId = 5,
                     CoursesId = 7
                 },
                 new CourseRoadmap
                 {
                     RoadmapId = 6,
                     CoursesId = 1
                 },
                 new CourseRoadmap
                 {
                     RoadmapId = 6,
                     CoursesId = 2
                 },
                 new CourseRoadmap
                 {
                     RoadmapId = 6,
                     CoursesId = 3
                 },
                 new CourseRoadmap
                 {
                     RoadmapId = 6,
                     CoursesId = 4
                 },
                 new CourseRoadmap
                 {
                     RoadmapId = 6,
                     CoursesId = 8
                 }

            );
        }
    }
}