using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StuMap.BLL.Services;
using StuMap.DAL.Models;
using System.Security.Claims;

namespace StuMap.Controllers
{
    [Authorize]
    public class ContactController(
        IContactService contactService) : Controller
    {
        public async Task<IActionResult> GetAllTickets()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await contactService.GetAll(userId);
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                // handle error
            }
            return View();
        }
        // todo: create a dto for this
        public async Task<IActionResult> NewTicket(Contact contact)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(ticket); 
            //}
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var result = await contactService.CreateNewTicket(userId, contact.Subject, contact.Body);
            if (result.Success)
            {
                return RedirectToAction("GetAllTickets");
            }
            else
            {
                // handle error
                return RedirectToAction("GetAllTickets");
            }
        }
    }
}
