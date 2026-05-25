using StuMap.BLL.Models;
using StuMap.BLL.Services;
using StuMap.DAL.Models;
using StuMap.DAL.Repositories.Interfaces;

namespace StuMap.BLL.Managers
{
    public class SpecializationService(
        IGenericRepository<Specialization> repo) : ISpecializationService
    {
        public async Task<ApiResponse<List<Specialization>>> GetAll()
        {
            try
            {
                var result = await repo.GetAllAsync();

                return ApiResponse<List<Specialization>>.SuccessResult([.. result]);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<List<Specialization>>.FailureResult("Error");
            }
        }
    }
}
