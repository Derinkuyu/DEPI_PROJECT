using StuMap.Models;

namespace StuMap.Managers
{
    public interface IMaterialManager: IGenericManager<Material>
    {
        public int InsertRange(List<Material> materials);
    }
}
