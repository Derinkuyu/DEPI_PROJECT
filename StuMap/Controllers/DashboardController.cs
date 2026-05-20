using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StuMap.Managers;
using StuMap.Models;

namespace StuMap.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    { 
        //Course
        ICourseManager courseManager;
        IRoadmapManager roadmapManager;
        UserManager<ApplicationUser> _userManger;
        ISpecializationManager specializationManager;
        IContributorManager contributorManager;

        public DashboardController(ICourseManager courseManager, IRoadmapManager roadmapManager, UserManager<ApplicationUser> userManger, ISpecializationManager specializationManager, IContributorManager contributorManager)
        {
            this.courseManager = courseManager;
            this.roadmapManager = roadmapManager;
            _userManger = userManger;
            this.specializationManager = specializationManager;
            this.contributorManager = contributorManager;
        }

        public async Task<IActionResult> Index()
        {
            var courses = courseManager.GetAll();
            var roadMaps = roadmapManager.GetAll();
            var users = _userManger.Users.ToList();
            var Specializations = specializationManager.GetAll();
            var ContributorRequests= contributorManager.GetPendingRequests();

            var roadmapStatusData = roadMaps.Select(r => new {
                Title = r.Title,
                IsApproved = r.IsApproved
            }).ToList();


            var RoadMapTitles = roadMaps.Select(x => x.Title).ToList();
            var SpecializationsTitles= Specializations.Select(s=> s.Name).ToList();

            var admins = await _userManger.GetUsersInRoleAsync("Admin");
            var contributors = await _userManger.GetUsersInRoleAsync("Contributor");
            var Students = await _userManger.GetUsersInRoleAsync("Student");
            

            ViewBag.Course = courses;
            ViewBag.RoadMaps = roadMaps;
            ViewBag.RoadMapTitles = RoadMapTitles;
            ViewBag.RoadmapStatusData = roadmapStatusData;
            ViewBag.SpecializationsTitles = SpecializationsTitles;

            ViewBag.UsersCount = users.Count-admins.Count;
            ViewBag.AdminCount = admins.Count;
            ViewBag.ContributorCount = contributors.Count;
            ViewBag.StudentCount = Students.Count;
            ViewBag.ContributorRequests = ContributorRequests.Count;


            return View();
        }
    }
}
