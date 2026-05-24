using StuMap.BLL.Models;
using StuMap.DAL.Models;

namespace StuMap.BLL.Services
{
    public interface IMaterialTypeService
    {
        public Task<ApiResponse<List<MaterialType>>> GetAll();
    }
}
