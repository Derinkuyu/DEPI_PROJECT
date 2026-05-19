using Microsoft.EntityFrameworkCore;
using StuMap.Models;

namespace StuMap.DataSeeding
{
    public class CourseRoadmapSeedConfiguration : IEntityTypeConfiguration<CourseRoadmap>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CourseRoadmap> builder)
        {
            // Seed data for CourseRoadmap entity
            builder.HasData(
                new CourseRoadmap
                {
                    RoadmapId = 1,
                    CourseId = 1
                },
                new CourseRoadmap
                {
                    RoadmapId = 1,
                    CourseId = 2
                },
                new CourseRoadmap
                {
                    RoadmapId = 1,
                    CourseId = 3
                },
                new CourseRoadmap
                {
                    RoadmapId = 1,
                    CourseId = 4
                },
                new CourseRoadmap
                {
                    RoadmapId = 2,
                    CourseId = 1
                },
                new CourseRoadmap
                {
                    RoadmapId = 2,
                    CourseId = 2
                },
                new CourseRoadmap
                {
                    RoadmapId = 2,
                    CourseId = 3
                },
                new CourseRoadmap
                {
                    RoadmapId = 2,
                    CourseId = 4
                }
            );
        }
    }
}