using StuMap.Models;

namespace StuMap.Managers
{
    public interface IRoadmapEnrollmentManager
    {
        public int Insert(RoadmapEnrollment entity);
        public bool IsEnrolled(string studentId, int roadmapId);
        public List<Roadmap> GetRoadmapsForStudent(string id);
        public int Delete(int roadmap, string studentId);
    }
}
