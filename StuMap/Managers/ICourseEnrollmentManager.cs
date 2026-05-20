using StuMap.Models;

namespace StuMap.Managers
{
    public interface ICourseEnrollmentManager 
    {
        public int Insert(CourseEnrollment entity);
        public bool IsEnrolled(string studentId, int courseId);
        public List<Course> GetCoursesForStudent(string id);
        public int Delete(int courseid , string studentId);
    }
}
