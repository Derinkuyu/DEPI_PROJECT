using Microsoft.EntityFrameworkCore;
using StuMap.Context;
using StuMap.Managers;
using StuMap.Models;

namespace StuMap.Services
{
    public class RoadmapRepository : IRoadmapManager
    {
        AppDbContext context;
        public RoadmapRepository(AppDbContext context)
        {
            this.context = context;
        }

        public List<Roadmap> GetAll()
        {
            return context.Roadmaps.Include(r => r.Specialization).Include(r => r.Contributor).Include(r => r.CourseRoadmaps).ThenInclude(cr => cr.Course).ThenInclude(c=>c.Materials).ThenInclude(c=>c.Contributor).ToList();
        }

        public Roadmap GetById(int id)
        {
            return context.Roadmaps.Include(r => r.Specialization).Include(r => r.Contributor).Include(r => r.CourseRoadmaps).ThenInclude(cr => cr.Course).ThenInclude(c => c.Materials).ThenInclude(c => c.Contributor).FirstOrDefault(r => r.Id == id);
        }

        public int Insert(Roadmap entity)
        {
            context.Roadmaps.Add(entity);
            context.SaveChanges();
            return entity.Id;
        }
     

        public int Update(int id, Roadmap entity)
        {
            var existingRoadmap = context.Roadmaps.Find(id);
            if (existingRoadmap != null)
            {
                existingRoadmap.Title = entity.Title;
                existingRoadmap.Description = entity.Description;
                existingRoadmap.ContributorId = entity.ContributorId;
                existingRoadmap.SpecializationId = entity.SpecializationId;

                return context.SaveChanges();
            }
            return 0;
        }
        public int Delete(int id)
        {
            var existingRoadmap = context.Roadmaps.Find(id);
            if (existingRoadmap != null)
            {
                context.Roadmaps.Remove(existingRoadmap);
                return context.SaveChanges();
            }
            return 0;

        }

       
    }
}
