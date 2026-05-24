using StuMap.BLL.Models;
using StuMap.BLL.Services;
using StuMap.DAL.Models;
using StuMap.DAL.Models.Enums;
using StuMap.DAL.Repositories.Interfaces;

namespace StuMap.BLL.Managers
{
    public class CourseService(
        IGenericRepository<Course> repo) : ICourseService
    {
        public async Task<ApiResponse<List<Course>>> GetApprovedCourses()
        {
            try
            {
                var result = (await repo.FindAsync(x => x.Status == StatusEnum.Approved)).ToList();


                return ApiResponse<List<Course>>.SuccessResult([.. result]);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<List<Course>>.FailureResult("Error");
            }
        }
    }
}
