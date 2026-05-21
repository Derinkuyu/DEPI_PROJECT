using StuMap.Models;

namespace StuMap.Managers
{
    public interface IContactManager: IGenericManager<Contact>
    {
        public List<Contact> GetAll(string userId);
        List<Contact> GetAll();

        Contact? GetDetails(int id);

        void Accept(int id, string reply);

        void Reject(int id, string reason);


    }
}
