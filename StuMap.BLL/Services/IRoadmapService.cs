using StuMap.BLL.Models;
using StuMap.DAL.Models;

namespace StuMap.BLL.Services
{
    public interface IRoadmapService
    {
        public Task<ApiResponse<List<Roadmap>>> GetApprovedRoadmaps();
        // todo: create a dto for this
        public Task<ApiResponse> SaveRoadmap(Roadmap roadmap, List<int> coursesId);


        public Task<ApiResponse<bool>> IsEnrolledInRoadmap(string? userId, int roadmapId);

        public Task<ApiResponse<List<Roadmap>>> GetEnrolledRoadmaps(string? studentId);
        public Task<ApiResponse> DropRoadmap(string? studentId, int roadmapId);
        public Task<ApiResponse> EnrollRoadmap(string? studentId, int roadmapId);

        public Task<ApiResponse<Roadmap>> GetRoadmap(int id);
        public Task<ApiResponse<List<Roadmap>>> GetMyRoadmaps(string? contributorId);
    }
}
