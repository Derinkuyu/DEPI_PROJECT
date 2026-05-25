using StuMap.BLL.Models;
using StuMap.DAL.Models;

namespace StuMap.BLL.Services.Admin
{
    public interface IAdminTicketService
    {
        public Task<ApiResponse<List<Contact>>> GetAllTickets();
        public Task<ApiResponse<Contact>> GetTicketById(int id);
        public Task<ApiResponse<List<Contact>>> GetTicketsByUser(string userId);
        public Task<ApiResponse> AcceptTicket(int id, string reply);
        public Task<ApiResponse> RejectTicket(int id, string reason);
        public Task<ApiResponse> DeleteTicket(int id);
    }
}
