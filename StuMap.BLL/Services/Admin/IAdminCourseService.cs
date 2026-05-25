using StuMap.BLL.DTO.Admin;
using StuMap.BLL.Models;
using StuMap.DAL.Models;

namespace StuMap.BLL.Services.Admin
{
    public interface IAdminCourseService
    {
        public Task<ApiResponse<List<CourseRequestDto>>> GetAllCourseRequests();
        public Task<ApiResponse<List<Course>>> GetAllCourses();
        public Task<ApiResponse<CourseDetailsDto>> GetCourseById(int id);
        public Task<ApiResponse> ApproveCourse(int id);
        public Task<ApiResponse> RejectCourse(int id, string reason);
        public Task<ApiResponse> DeleteCourse(int id);

        public Task<ApiResponse<int>> GetPendingCoursesCount();
    }
}
