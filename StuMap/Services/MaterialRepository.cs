using Microsoft.EntityFrameworkCore;
using StuMap.Context;
using StuMap.Managers;
using StuMap.Models;

namespace StuMap.Services
{
    public class MaterialRepository : IMaterialManager
    {
        AppDbContext context;
        public MaterialRepository(AppDbContext context)
        {
            this.context = context;
        }
        public List<Material> GetAll()
        {
         return context.Materials.Include(m => m.Contributor).Include(m => m.Course).ToList();
        }

        public Material GetById(int id)
        { 
            return context.Materials.Include(m => m.Contributor).Include(m => m.Course).FirstOrDefault(m => m.Id == id);
        }

        public int Insert(Material entity)
        {
            context.Materials.Add(entity);
            return context.SaveChanges();
        }

        public int Update(int id, Material entity)
        {
                        var existingMaterial = context.Materials.Find(id);
                        if (existingMaterial != null)
                        {
                            existingMaterial.Title = entity.Title;
                            existingMaterial.Description = entity.Description;
                            existingMaterial.CourseId = entity.CourseId;
                            existingMaterial.MaterialType = entity.MaterialType;

                        return context.SaveChanges();
                        }
                        return 0;
        }
        public int Delete(int id)
        {
            var existingMaterial = context.Materials.Find(id);
            if (existingMaterial != null)
            {
                context.Materials.Remove(existingMaterial);
                return context.SaveChanges();
            }
            return 0;
        }



    }
}
