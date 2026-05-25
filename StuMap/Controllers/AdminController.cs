using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StuMap.BLL.Services.Admin;

namespace StuMap.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController(
        IAdminUserService adminUserService,
        IAdminContributorService adminContributorService,
        IAdminRoadmapService adminRoadmapService,
        IAdminCourseService adminCourseService,
        IAdminTicketService adminTicketService) : Controller
    {
        /*------------------------------------------------------------------------------------*/
        /////////// Users Management
        /*------------------------------------------------------------------------------------*/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await adminUserService.GetAllUsers();
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                // todo: handle errors
                return View();
            }
        }
        /*------------------------------------------------------------------------------------*/
        [HttpGet]

        public async Task<IActionResult> Details(string id)
        {
            var result = await adminUserService.GetUserDetails(id);

            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                // todo: handle errors
                return View();
            }
        }
        /*------------------------------------------------------------------------------------*/
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await adminUserService.DeleteUser(id);

            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // todo: handle errors
                return RedirectToAction("Index");
            }
        }
        /*------------------------------------------------------------------------------------*/
        public async Task<IActionResult> Block(string id)
        {
            var result = await adminUserService.BlockUser(id);

            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // todo: handle errors
                return RedirectToAction("Index");
            }
        }
        /*------------------------------------------------------------------------------------*/
        public async Task<IActionResult> UnBlock(string id)
        {
            var result = await adminUserService.UnblockUser(id);

            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // todo: handle errors
                return RedirectToAction("Index");
            }
        }
        /*------------------------------------------------------------------------------------*/
        /////////// Contributors Management
        /*------------------------------------------------------------------------------------*/
        public async Task<IActionResult> ContributorRequests()
        {
            var result = await adminContributorService.GetAllContributors();

            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                // todo: handle errors
                return View();
            }
        }
        /*------------------------------------------------------------------------------------*/
        public async Task<IActionResult> ContributorDetails(string id)
        {
            var result = await adminContributorService.GetContributorById(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                // todo: handle errors
                return View();
            }
        }
        /*------------------------------------------------------------------------------------*/
        public async Task<IActionResult> ApproveContributor(string id)
        {
            var result = await adminContributorService.ApproveContributor(id);
            if (result.Success)
            {
                return RedirectToAction("ContributorRequests");
            }
            else
            {
                // todo: handle errors
                return RedirectToAction("ContributorRequests");
            }

        }
        /*------------------------------------------------------------------------------------*/
        [HttpPost]
        public async Task<IActionResult> RejectContributor(string id, string reason)
        {
            var result = await adminContributorService.RejectContributor(id, reason);
            if (result.Success)
            {
                return RedirectToAction("ContributorRequests");
            }
            else
            {
                // todo: handle errors
                return RedirectToAction("ContributorRequests");
            }
        }
        /*------------------------------------------------------------------------------------*/
        //////////// Roadmaps Management
        /*------------------------------------------------------------------------------------*/
        public async Task<IActionResult> RoadmapRequests()
        {
            var result = await adminRoadmapService.GetAllRoadmaps();
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                // todo: handle errors
                return View();
            }
        }
        /*------------------------------------------------------------------------------------*/
        public async Task<IActionResult> RoadmapDetails(int id)
        {
            var result = await adminRoadmapService.GetRoadmapById(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                // todo: handle errors
                return View();
            }
        }
        /*------------------------------------------------------------------------------------*/
        public async Task<IActionResult> ApproveRoadmap(int id)
        {
            var result = await adminRoadmapService.ApproveRoadmap(id);
            if (result.Success)
            {
                return RedirectToAction("RoadmapRequests");
            }
            else
            {
                // todo: handle errors
                return RedirectToAction("RoadmapRequests");
            }
        }
        /*------------------------------------------------------------------------------------*/
        [HttpPost]
        public async Task<IActionResult> RejectRoadmap(int id, string reason)
        {
            var result = await adminRoadmapService.RejectRoadmap(id, reason);
            if (result.Success)
            {
                return RedirectToAction("RoadmapRequests");
            }
            else
            {
                // todo: handle errors
                return RedirectToAction("RoadmapRequests");
            }
        }
        /*------------------------------------------------------------------------------------*/
        public async Task<IActionResult> DeleteRoadmap(int id)
        {
            var result = await adminRoadmapService.DeleteRoadmap(id);
            if (result.Success)
            {
                return RedirectToAction("RoadmapRequests");
            }
            else
            {
                // todo: handle errors
                return RedirectToAction("RoadmapRequests");
            }
        }
        /*------------------------------------------------------------------------------------*/
        //////////// Course Management
        /*------------------------------------------------------------------------------------*/
        public async Task<IActionResult> CourseRequests()
        {
            var result = await adminCourseService.GetAllCourseRequests();
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                // todo: handle errors
                return View();
            }
        }
        /*------------------------------------------------------------------------------------*/
        public async Task<IActionResult> CourseDetails(int id)
        {
            var result = await adminCourseService.GetCourseById(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                // todo: handle errors
                return View();
            }
        }
        /*------------------------------------------------------------------------------------*/
        public async Task<IActionResult> ApproveCourse(int id)
        {
            var result = await adminCourseService.ApproveCourse(id);
            if (result.Success)
            {
                return RedirectToAction("CourseRequests");
            }
            else
            {
                // todo: handle errors
                return RedirectToAction("CourseRequests");
            }
        }
        /*------------------------------------------------------------------------------------*/
        [HttpPost]
        public async Task<IActionResult> RejectCourse(int id, string reason)
        {
            var result = await adminCourseService.RejectCourse(id, reason);
            if (result.Success)
            {
                return RedirectToAction("CourseRequests");
            }
            else
            {
                // todo: handle errors
                return RedirectToAction("CourseRequests");
            }
        }
        /*------------------------------------------------------------------------------------*/
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await adminCourseService.DeleteCourse(id);
            if (result.Success)
            {
                return RedirectToAction("CourseRequests");
            }
            else
            {
                // todo: handle errors
                return RedirectToAction("CourseRequests");
            }
        }
        /*------------------------------------------------------------------------------------*/
        ////////// Tickets Management
        /*------------------------------------------------------------------------------------*/
        public async Task<IActionResult> TicketRequests()
        {
            var result = await adminTicketService.GetAllTickets();
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                // todo: handle errors
                return View();
            }

        }
        /*------------------------------------------------------------------------------------*/
        // Ticket details view (uses ContactDetailsDto)
        public async Task<IActionResult> TicketDetails(int id)
        {
            var result = await adminTicketService.GetTicketById(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                if (result.StatusCode == System.Net.HttpStatusCode.NotFound) return NotFound();

                // todo: handle errors
                return View();
            }
        }
        /*------------------------------------------------------------------------------------*/
        // Accept a ticket and optionally send a reply (POST)
        [HttpPost]
        public async Task<IActionResult> AcceptTicket(int id, string reply)
        {
            var result = await adminTicketService.AcceptTicket(id, reply);
            if (result.Success)
            {
                return RedirectToAction("TicketRequests");
            }
            else
            {
                // todo: handle errors
                return RedirectToAction("TicketRequests");
            }
        }
        /*------------------------------------------------------------------------------------*/
        // Reject a ticket with reason (POST)
        [HttpPost]
        public async Task<IActionResult> RejectTicket(int id, string reason)
        {
            var result = await adminTicketService.RejectTicket(id, reason);
            if (result.Success)
            {
                return RedirectToAction("TicketRequests");
            }
            else
            {
                // todo: handle errors
                return RedirectToAction("TicketRequests");
            }
        }
        /*------------------------------------------------------------------------------------*/
        // Delete ticket
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var result = await adminTicketService.DeleteTicket(id);
            if (result.Success)
            {
                return RedirectToAction("TicketRequests");
            }
            else
            {
                // todo: handle errors
                return RedirectToAction("TicketRequests");
            }
        }
        /*------------------------------------------------------------------------------------*/
    }
}
