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
            return context.Roadmaps.Include(r => r.Courses).Include(r => r.Specialization).Include(r => r.Contributor).ToList();
        }

        public Roadmap GetById(int id)
        {
            return context.Roadmaps.Include(r => r.Courses).Include(r => r.Specialization).Include(r => r.Contributor).FirstOrDefault(r => r.Id == id);
        }

        public int Insert(Roadmap entity)
        {
            context.Roadmaps.Add(entity);
            return context.SaveChanges();
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
