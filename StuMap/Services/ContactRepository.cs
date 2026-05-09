using Microsoft.EntityFrameworkCore;
using StuMap.Context;
using StuMap.Managers;
using StuMap.Models;

namespace StuMap.Services
{
    public class ContactRepository : IContactManager
    {
        AppDbContext context;
        public ContactRepository(AppDbContext context)
        {
            this.context = context;
        }
        public List<Contact> GetAll()
        {
            return context.Contacts.Include(c => c.User).ToList();
        }

        public Contact GetById(int id)
        {
            return context.Contacts.Include(c => c.User).FirstOrDefault(c => c.Id == id);
        }

        public int Insert(Contact entity)
        {
            context.Contacts.Add(entity);
            return context.SaveChanges();
        }

        // there should be no update for contact as it is a message sent by user, but we will implement it anyway
        public int Update(int id, Contact entity)
        {
            throw new NotImplementedException();
        }
        public int Delete(int id)
        {
            var oldContact = GetById(id);
            if (oldContact != null)
            {
                context.Contacts.Remove(oldContact);
                return context.SaveChanges();
            }
            return 0;
        }
       
    }
}
