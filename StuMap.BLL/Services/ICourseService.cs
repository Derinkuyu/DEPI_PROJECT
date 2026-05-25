using StuMap.BLL.Models;
using StuMap.DAL.Models;

namespace StuMap.BLL.Services
{
    public interface ICourseService
    {
        public Task<ApiResponse<List<Course>>> GetApprovedCourses();
        // todo: create a dto for this
        public Task<ApiResponse> SaveCourseAndMaterials(Course course, List<Material> materials);

        public Task<ApiResponse<bool>> IsEnrolledInCourse(string? userId, int courseId);
        public Task<ApiResponse<List<Course>>> GetEnrolledCourses(string? studentId);
        public Task<ApiResponse> DropCourse(string? studentId, int courseId);
        public Task<ApiResponse> EnrollCourse(string? studentId, int courseId);


        public Task<ApiResponse<Course>> GetCourse(int id);
        public Task<ApiResponse<List<Course>>> GetMyCourses(string? contributorId);
    }
}
