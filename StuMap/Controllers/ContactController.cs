using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StuMap.Managers;
using StuMap.Models;
using System.Net.Sockets;
using System.Security.Claims;

namespace StuMap.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        INotificationManager notificationManager;
        IContactManager contactManager;
        UserManager<ApplicationUser> userManager;
        public ContactController(INotificationManager notificationManager, IContactManager contactManager, UserManager<ApplicationUser> userManager)
        {
            this.notificationManager = notificationManager;
            this.contactManager = contactManager;
            this.userManager = userManager;
        }
        public IActionResult GetAllTickets()
        {
            var stuId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tickets = contactManager.GetAll(stuId);
            return View(tickets);
        }
        public async Task<IActionResult> NewTicket(Contact contact)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(ticket); 
            //}
            var stuId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            contactManager.Insert(new Contact
            {
                UserId = stuId,
                Subject = contact.Subject,
                Body = contact.Body,
                DateSent = DateTime.Now
            });

            var admin = await userManager.GetUsersInRoleAsync("Admin");
            var adminId = admin.FirstOrDefault()?.Id;
            string title = "New Ticket";
            string body = $"A new ticket has been created by student with ID: {stuId}. Subject: {contact.Subject}";
            await notificationManager.SendNotificationAsync(adminId, title, body);

            return RedirectToAction("GetAllTickets");
        }
    }
}
