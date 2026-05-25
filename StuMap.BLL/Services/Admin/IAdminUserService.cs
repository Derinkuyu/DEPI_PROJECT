using StuMap.BLL.DTO.Admin;
using StuMap.BLL.Models;

namespace StuMap.BLL.Services.Admin
{
    public interface IAdminUserService
    {
        public Task<ApiResponse<List<UserDto>>> GetAllUsers();
        public Task<ApiResponse<UserDetailsDto>> GetUserDetails(string id);
        public Task<ApiResponse> DeleteUser(string id);
        public Task<ApiResponse> BlockUser(string id);
        public Task<ApiResponse> UnblockUser(string id);

        public Task<ApiResponse<int>> CountUsersInRole(string role);

    }
}
