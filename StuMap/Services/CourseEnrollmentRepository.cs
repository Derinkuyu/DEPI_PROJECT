using Microsoft.EntityFrameworkCore;
using StuMap.Context;
using StuMap.Managers;
using StuMap.Models;

namespace StuMap.Services
{
    public class CourseEnrollmentRepository(AppDbContext context) : ICourseEnrollmentManager
    {
      
        public List<Course> GetCoursesForStudent(string id)
        {
            var result = context.CourseEnrollments.Where(e => e.StudentId == id).Include(e => e.Course)
                .ThenInclude(c => c!.Contributor).Select(e => e.Course!);

            return [.. result];
        }

        public bool IsEnrolled(string studentId, int courseId)
        {
            return context.CourseEnrollments.Any(e => e.StudentId == studentId && e.CourseId == courseId);
        }

        public int Insert(CourseEnrollment entity)
        {
            context.CourseEnrollments.Add(entity);
            return context.SaveChanges();
        }

        public int Delete(int courseid, string studentId)
        {
            var enrollment = context.CourseEnrollments.FirstOrDefault(e => e.CourseId == courseid && e.StudentId == studentId);
            if (enrollment != null)
            {
                context.CourseEnrollments.Remove(enrollment);
                context.SaveChanges();
                return 1;
            }
            return 0;
        }

    }
}
