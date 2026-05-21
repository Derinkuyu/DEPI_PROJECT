using Microsoft.EntityFrameworkCore;
using StuMap.Context;
using StuMap.Managers;
using StuMap.Models;

namespace StuMap.Services
{
    public class RoadmapEnrollmentRepository(AppDbContext context) : IRoadmapEnrollmentManager
    {
        public List<Roadmap> GetRoadmapsForStudent(string id)
        {
            var result = context.RoadmapEnrollment
               .Where(e => e.StudentId == id)
               .Include(e => e.Roadmap)!
                   .ThenInclude(r => r!.Contributor)
               .Include(e => e.Roadmap)!
                   .ThenInclude(r => r!.Specialization)
               .Include(e => e.Roadmap)!
                   .ThenInclude(r => r!.CourseRoadmaps)
               .Select(e => e.Roadmap!);
            return [.. result];
        }

        public bool IsEnrolled(string studentId, int roadmapId)
        {
            return context.RoadmapEnrollment.Any(e => e.StudentId == studentId && e.RoadmapId == roadmapId);
        }

        public int Insert(RoadmapEnrollment entity)
        {
            context.RoadmapEnrollment.Add(entity);
            return context.SaveChanges();
        }

        public int Delete(int roadmapid, string studentId)
        {
            var enrollment = context.RoadmapEnrollment.FirstOrDefault(e => e.RoadmapId == roadmapid && e.StudentId == studentId);
            if (enrollment != null)
            {
                context.RoadmapEnrollment.Remove(enrollment);
                context.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
