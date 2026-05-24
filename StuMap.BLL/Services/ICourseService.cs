using StuMap.BLL.Models;
using StuMap.DAL.Models;

namespace StuMap.BLL.Services
{
    public interface ICourseService
    {
        public Task<ApiResponse<List<Course>>> GetApprovedCourses();
    }
}
