using StuMap.Models;

namespace StuMap.Managers
{
    public interface ICourseRoadmapManager: IGenericManager<CourseRoadmap>
    {
        public int InsertRange(List<CourseRoadmap> courseRoadmaps);
    }
}
