using StuMap.BLL.Models;
using StuMap.DAL.Models;

namespace StuMap.BLL.Services
{
    public interface ISpecializationService
    {
        public Task<ApiResponse<List<Specialization>>> GetAll();
    }
}
