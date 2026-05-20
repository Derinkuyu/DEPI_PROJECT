using Microsoft.EntityFrameworkCore;
using StuMap.Context;
using StuMap.Managers;
using StuMap.Models;

namespace StuMap.Services
{
    public class CourseEnrollmentRepository : ICourseEnrollmentManager
    {
        AppDbContext context;
        public CourseEnrollmentRepository(AppDbContext context)
        {
            this.context = context;
        }
        //public List<Course> GetAll(string studentId)
        //{
           
        //    context.CourseEnrollments.Where(s => s.StudentId == studentId).Select(Course)Include(e => e.Student).Include(e => e.CourseId).ToList();
        //}
        public List<Course> GetCoursesForStudent(string id)
        {
            return context.CourseEnrollments
            .Where(e => e.StudentId == id)
            .Include(e => e.Course)
                .ThenInclude(c => c.Contributor)
            .Select(e => e.Course)
            .ToList();
        }

        public bool IsEnrolled (string studentId, int courseId)
        {
            return context.CourseEnrollments.Any(e => e.StudentId == studentId && e.CourseId == courseId);
        }

        public int Insert(CourseEnrollment entity)
        {
            context.CourseEnrollments.Add(entity);
            return context.SaveChanges();
        }
        //the enrollment mustn't be updated

        public int Delete(int courseid , string studentId)
        {
            var enrollment = context.CourseEnrollments.FirstOrDefault(e => e.CourseId == courseid && e.StudentId == studentId);
            if(enrollment != null)
            {
                context.CourseEnrollments.Remove(enrollment);
                context.SaveChanges();
                return 1;
            }
            return 0;
        }
   
    }
}
