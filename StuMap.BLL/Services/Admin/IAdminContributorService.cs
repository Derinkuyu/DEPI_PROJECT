using StuMap.BLL.DTO.Admin;
using StuMap.BLL.Models;

namespace StuMap.BLL.Services.Admin
{
    public interface IAdminContributorService
    {
        public Task<ApiResponse<List<ContributorRequestDto>>> GetAllContributors();
        //public Task<ApiResponse<List<ContributorRequestDto>>> GetPendingContributors();
        public Task<ApiResponse<ContributorDetailsDto>> GetContributorById(string id);
        public Task<ApiResponse> ApproveContributor(string id);
        public Task<ApiResponse> RejectContributor(string id, string reason);
    }
}
