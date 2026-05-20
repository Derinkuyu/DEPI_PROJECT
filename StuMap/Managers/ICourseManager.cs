using StuMap.DTO.Admin;
using StuMap.Models;

namespace StuMap.Managers
{
    public interface ICourseManager: IGenericManager<Course>
    {
        List<CourseRequestDto> GetPendingCourses();

        List<CourseRequestDto> GetAllCourses();

        CourseDetailsDto GetCourseById(int id);

        void ApproveCourse(int id);

        void RejectCourse(int id, string reason);

        void DeleteCourse(int id);
    }
}
