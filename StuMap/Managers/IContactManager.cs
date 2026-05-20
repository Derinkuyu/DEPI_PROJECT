using StuMap.Models;

namespace StuMap.Managers
{
    public interface IContactManager: IGenericManager<Contact>
    {
        public List<Contact> GetAll(string userId);

    }
}
