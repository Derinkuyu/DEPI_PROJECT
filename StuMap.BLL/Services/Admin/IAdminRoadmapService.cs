using StuMap.BLL.DTO.Admin;
using StuMap.BLL.Models;

namespace StuMap.BLL.Services.Admin
{
    public interface IAdminRoadmapService
    {
        public Task<ApiResponse<List<RoadmapRequestDto>>> GetAllRoadmaps();
        public Task<ApiResponse<RoadmapDetailsDto>> GetRoadmapById(int id);
        public Task<ApiResponse> ApproveRoadmap(int id);
        public Task<ApiResponse> RejectRoadmap(int id, string reason);
        public Task<ApiResponse> DeleteRoadmap(int id);

        public Task<ApiResponse<List<(string title, bool isApproved)>>> GetRoadmapsStatus();
        public Task<ApiResponse<int>> GetPendingRoadmapsCount();
    }
}
