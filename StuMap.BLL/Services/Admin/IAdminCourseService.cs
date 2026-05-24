using StuMap.BLL.DTO.Admin;
using StuMap.BLL.Models;

namespace StuMap.BLL.Services.Admin
{
    public interface IAdminCourseService
    {
        public Task<ApiResponse<List<CourseRequestDto>>> GetAllCourses();
        public Task<ApiResponse<CourseDetailsDto>> GetCourseById(int id);
        public Task<ApiResponse> ApproveCourse(int id);
        public Task<ApiResponse> RejectCourse(int id, string reason);
        public Task<ApiResponse> DeleteCourse(int id);
    }
}
