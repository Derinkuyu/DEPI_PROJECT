using StuMap.Context;
using StuMap.Managers;
using StuMap.Models;

namespace StuMap.Services
{
    public class CourseRoadmapRepository : ICourseRoadmapManager
    {
        AppDbContext context;
        public CourseRoadmapRepository(AppDbContext context)
        {
            this.context = context;
        }
        public List<CourseRoadmap> GetAll()
        {
            throw new NotImplementedException();
        }

        public CourseRoadmap GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(CourseRoadmap entity)
        {
            throw new NotImplementedException();
        }
        public int InsertRange(List<CourseRoadmap> courseRoadmaps)
        {
            context.CourseRoadmaps.AddRange(courseRoadmaps);
            return context.SaveChanges();
        }

        public int Update(int id, CourseRoadmap entity)
        {
            throw new NotImplementedException();
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
