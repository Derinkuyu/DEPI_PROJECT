using StuMap.DTO.Admin;
using StuMap.Models;

namespace StuMap.Managers
{
    public interface IRoadmapManager : IGenericManager<Roadmap>
    {
        List<RoadmapRequestDto> GetPendingRoadmaps();

        List<RoadmapRequestDto> GetAllRoadmaps();

        RoadmapDetailsDto GetRoadmapById(int id);

        void ApproveRoadmap(int id);

        void RejectRoadmap(int id, string reason);

        void DeleteRoadmap(int id);
    }
}
