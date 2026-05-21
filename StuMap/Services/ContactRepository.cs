using Microsoft.EntityFrameworkCore;
using StuMap.Context;
using StuMap.Managers;
using StuMap.Models;

namespace StuMap.Services
{
    public class ContactRepository : IContactManager
    {
        /*------------------------------------------------------------------------------------*/

        AppDbContext context;
        /*------------------------------------------------------------------------------------*/
        public ContactRepository(AppDbContext context)
        {
            this.context = context;
        }
        /*------------------------------------------------------------------------------------*/

        public List<Contact> GetAll()
        {
            return context.Contacts
                .Include(c => c.User)
                .OrderByDescending(c => c.DateSent)
                .ToList();
        }
        /*------------------------------------------------------------------------------------*/
        public List<Contact> GetAll(string userId)
        {
            return context.Contacts
                .Include(c => c.User)
                .Where(c => c.UserId == userId)
                .OrderByDescending(e => e.DateSent)
                .ToList();
        }
        /*------------------------------------------------------------------------------------*/

        public Contact GetById(int id)
        {
            return context.Contacts
                .Include(c => c.User)
                .FirstOrDefault(c => c.Id == id);
        }
        /*------------------------------------------------------------------------------------*/

        public int Insert(Contact entity)
        {
            context.Contacts.Add(entity);
            return context.SaveChanges();
        }
        /*------------------------------------------------------------------------------------*/

        // there should be no update for contact as it is a message sent by user, but we will implement it anyway
        public int Update(int id, Contact entity)
        {
            throw new NotImplementedException();
        }
        /*------------------------------------------------------------------------------------*/
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
        /*------------------------------------------------------------------------------------*/

        public Contact? GetDetails(int id)
        {
            var contact = GetById(id);
            if (contact != null)
            {
                contact.IsRead = true;
                context.Contacts.Update(contact);
                context.SaveChanges();
            }
            return contact;
        }
        /*------------------------------------------------------------------------------------*/
        public void Accept(int id, string reply)
        {
            var contact = GetById(id);
            if (contact != null)
            {
                contact.Status = Models.Enums.TicketStatus.Considered;
                contact.AdminReply = reply;
                context.Contacts.Update(contact);
                context.SaveChanges();
            }
        }
        /*------------------------------------------------------------------------------------*/

        public void Reject(int id, string reason)
        {
            var contact = GetById(id);
            if (contact != null)
            {
                contact.Status = Models.Enums.TicketStatus.Denied;
                contact.RejectionReason = reason;
                context.Contacts.Update(contact);
                context.SaveChanges();
            }
        }
        /*------------------------------------------------------------------------------------*/
    }
}
