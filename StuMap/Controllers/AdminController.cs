using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuMap.Managers;
using StuMap.Models.Enums;

namespace StuMap.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        /*------------------------------------------------------------------------------------*/
        private readonly IUserManager _userManager;
        private readonly IContributorManager _contributorManager;
        private readonly IRoadmapManager _roadmapManager;
        private readonly ICourseManager _courseManager;
        private readonly IContactManager _contactManager;

        /*------------------------------------------------------------------------------------*/
        public AdminController(
            IUserManager userManager, 
            IContributorManager contributorManager, 
            IRoadmapManager roadmapManager, 
            ICourseManager courseManager,
            IContactManager contactManager)
        {
            _userManager = userManager;
            _contributorManager = contributorManager;
            _roadmapManager = roadmapManager;
            _courseManager = courseManager;
            _contactManager = contactManager;
        }
        /*------------------------------------------------------------------------------------*/
        /////////// Users Management
        /*------------------------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Index()
        {
            var users = _userManager.GetAll();
            return View(users);
        }
        /*------------------------------------------------------------------------------------*/
        [HttpGet]

        public IActionResult Details(string id)
        {
            var user = _userManager.GetById(id);

            return View(user);
        }
        /*------------------------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Delete(string id)
        {
            _userManager.Delete(id);

            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------------------------*/
        public IActionResult Block(string id)
        {
            _userManager.Block(id);

            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------------------------*/
        public IActionResult UnBlock(string id)
        {
            _userManager.Unblock(id);

            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------------------------*/
        /////////// Contributors Management
        /*------------------------------------------------------------------------------------*/
        public IActionResult ContributorRequests()
        {
            //var requests = _contributorManager.GetPendingRequests();
            var requests = _contributorManager.GetAllContributors();

            return View(requests);
        }
        /*------------------------------------------------------------------------------------*/
        public IActionResult ContributorDetails(string id)
        {
            var contributor = _contributorManager.GetContributorById(id);

            return View(contributor);
        }
        /*------------------------------------------------------------------------------------*/
        public IActionResult ApproveContributor(string id)
        {
            _contributorManager.ApproveContributor(id);

            return RedirectToAction("ContributorRequests");
        }
        /*------------------------------------------------------------------------------------*/
        [HttpPost]
        public IActionResult RejectContributor(string id, string reason)
        {
            _contributorManager.RejectContributor(id, reason);

            return RedirectToAction("ContributorRequests");
        }
        /*------------------------------------------------------------------------------------*/
        //////////// Roadmaps Management
        /*------------------------------------------------------------------------------------*/
        public IActionResult RoadmapRequests()
        {
            //var roadmaps = _roadmapManager.GetPendingRoadmaps();
            var roadmaps = _roadmapManager.GetAllRoadmaps();

            return View(roadmaps);
        }
        /*------------------------------------------------------------------------------------*/
        public IActionResult RoadmapDetails(int id)
        {
            var roadmap = _roadmapManager.GetRoadmapById(id);

            return View(roadmap);
        }
        /*------------------------------------------------------------------------------------*/
        public IActionResult ApproveRoadmap(int id)
        {
            _roadmapManager.ApproveRoadmap(id);

            return RedirectToAction("RoadmapRequests");
        }
        /*------------------------------------------------------------------------------------*/
        [HttpPost]
        public IActionResult RejectRoadmap(int id, string reason)
        {
            _roadmapManager.RejectRoadmap(id, reason);

            return RedirectToAction("RoadmapRequests");
        }
        /*------------------------------------------------------------------------------------*/
        public IActionResult DeleteRoadmap(int id)
        {
            _roadmapManager.DeleteRoadmap(id);

            return RedirectToAction("RoadmapRequests");
        }
        /*------------------------------------------------------------------------------------*/
        //////////// Course Management
        /*------------------------------------------------------------------------------------*/
        public IActionResult CourseRequests()
        {
            //var courses = _courseManager.GetPendingCourses();
            var courses = _courseManager.GetAllCourses();

            return View(courses);
        }
        /*------------------------------------------------------------------------------------*/
        public IActionResult CourseDetails(int id)
        {
            var course = _courseManager.GetCourseById(id);

            return View(course);
        }
        /*------------------------------------------------------------------------------------*/
        public IActionResult ApproveCourse(int id)
        {
            _courseManager.ApproveCourse(id);

            return RedirectToAction("CourseRequests");
        }
        /*------------------------------------------------------------------------------------*/
        [HttpPost]
        public IActionResult RejectCourse(int id, string reason)
        {
            _courseManager.RejectCourse(id, reason);

            return RedirectToAction("CourseRequests");
        }
        /*------------------------------------------------------------------------------------*/
        public IActionResult DeleteCourse(int id)
        {
            _courseManager.DeleteCourse(id);

            return RedirectToAction("CourseRequests");
        }
        /*------------------------------------------------------------------------------------*/
        ////////// Tickets Management
        /*------------------------------------------------------------------------------------*/
        public IActionResult TicketRequests()
        {
            var tickets = _contactManager.GetAll();
            return View(tickets);
        }
        /*------------------------------------------------------------------------------------*/
        // Ticket details view (uses ContactDetailsDto)
        public IActionResult TicketDetails(int id)
        {
            var ticket = _contactManager.GetDetails(id);
            if (ticket == null) return NotFound();
            return View(ticket);
        }
        /*------------------------------------------------------------------------------------*/
        // Accept a ticket and optionally send a reply (POST)
        [HttpPost]
        public IActionResult AcceptTicket(int id, string reply)
        {
            _contactManager.Accept(id, reply);
            return RedirectToAction("TicketRequests");
        }
        /*------------------------------------------------------------------------------------*/
        // Reject a ticket with reason (POST)
        [HttpPost]
        public IActionResult RejectTicket(int id, string reason)
        {
            _contactManager.Reject(id, reason);
            return RedirectToAction("TicketRequests");
        }
        /*------------------------------------------------------------------------------------*/
        // Delete ticket
        public IActionResult DeleteTicket(int id)
        {
            _contactManager.Delete(id);
            return RedirectToAction("TicketRequests");
        }
        /*------------------------------------------------------------------------------------*/
    }
}
