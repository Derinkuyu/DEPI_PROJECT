using StuMap.Context;
using StuMap.Managers;
using StuMap.Models;

namespace StuMap.Services
{
    public class MaterialTypeRepository : IMaterialTypeManager
    {
        AppDbContext context;
        public MaterialTypeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<MaterialType> GetAll()
        {
            return context.MaterialTypes.ToList();
        }

        public MaterialType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(MaterialType entity)
        {
            throw new NotImplementedException();
        }

        public int Update(int id, MaterialType entity)
        {
            throw new NotImplementedException();
        }
    }
}
