using StuMap.BLL.Models;
using StuMap.BLL.Services;
using StuMap.DAL.Models;
using StuMap.DAL.Repositories.Interfaces;

namespace StuMap.BLL.Managers
{
    public class MaterialTypeService(
        IGenericRepository<MaterialType> repo) : IMaterialTypeService
    {
        public async Task<ApiResponse<List<MaterialType>>> GetAll()
        {
            try
            {
                var result = await repo.GetAllAsync();

                return ApiResponse<List<MaterialType>>.SuccessResult([.. result]);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<List<MaterialType>>.FailureResult("Error");
            }
        }
    }
}
