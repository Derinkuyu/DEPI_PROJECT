using StuMap.BLL.Models;
using StuMap.DAL.Models;

namespace StuMap.BLL.Services
{
    public interface IContactService
    {
        public Task<ApiResponse<List<Contact>>> GetAll(string? userId);
        public Task<ApiResponse> CreateNewTicket(string? userId, string subject, string body);
    }
}
