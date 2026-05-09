using Microsoft.EntityFrameworkCore;
using StuMap.Context;
using StuMap.Managers;
using StuMap.Models;

namespace StuMap.Services
{
    public class SpecializationRepository : ISpecializationManager
    {
        AppDbContext context;
        public SpecializationRepository(AppDbContext context)
        {
            this.context = context;
        }
        public List<Specialization> GetAll()
        {
            return context.Specializations.Include(s => s.Roadmaps).ToList();
        }

        public Specialization GetById(int id)
        {
            return context.Specializations.Include(s => s.Roadmaps).FirstOrDefault(s => s.Id == id);
        }

        public int Insert(Specialization entity)
        {
            context.Specializations.Add(entity);
            return context.SaveChanges();
        }

        public int Update(int id, Specialization entity)
        {
            var existingSpecialization = context.Specializations.Find(id);
            if (existingSpecialization != null)
            {
                existingSpecialization.Name = entity.Name;
                existingSpecialization.Description = entity.Description;
                return context.SaveChanges();
            }
            return 0;
        }
        public int Delete(int id)
        {
            var existingSpecialization = GetById(id);
            if (existingSpecialization != null)
            {
                context.Specializations.Remove(existingSpecialization);
                return context.SaveChanges();
            }
            return 0;
        }

        
    }
}
