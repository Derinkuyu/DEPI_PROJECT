using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StuMap.BLL.Services;
using StuMap.BLL.Services.Admin;

namespace StuMap.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController(
        IAdminCourseService courseService,
        IAdminRoadmapService roadmapService,
        IAdminUserService userService,
        ISpecializationService specializationService,
        IAdminContributorService contributorService) : Controller
    {
        public async Task<IActionResult> Index()
        {

            var roadmapsData = await roadmapService.GetRoadmapsStatus();
            if (roadmapsData.Success)
            {
                var roadmapStatusData = roadmapsData.Data!.Select(r => new
                {
                    Title = r.title,
                    IsApproved = r.isApproved
                }).ToList();
                ViewBag.RoadmapStatusData = roadmapStatusData;

                var RoadMapTitles = roadmapsData.Data!.Select(x => x.title).ToList();
                ViewBag.RoadMapTitles = RoadMapTitles;
            }

            int adminsCount = (await userService.CountUsersInRole("Admin")).Data;
            int contributorsCount = (await userService.CountUsersInRole("Contributor")).Data;
            int studentsCount = (await userService.CountUsersInRole("Student")).Data;

            ViewBag.UsersCount = contributorsCount + studentsCount;
            ViewBag.AdminCount = adminsCount;
            ViewBag.ContributorCount = contributorsCount;
            ViewBag.StudentCount = studentsCount;



            var Specializations = await specializationService.GetAll();
            if(Specializations.Success)
            {
                var SpecializationsTitles = Specializations.Data!.Select(s => s.Name).ToList();

                ViewBag.SpecializationsTitles = SpecializationsTitles;
            }




            //ViewBag.ContributorRequests = ContributorRequests.Count;

            // todo: handle errors
            ViewBag.ContributorRequests = (await contributorService.GetPendingContributorsCount()).Data;

            ViewBag.PendingRoadmapsCount = (await roadmapService.GetPendingRoadmapsCount()).Data;

            ViewBag.PendingCoursesCount = (await courseService.GetPendingCoursesCount()).Data;


            return View();
        }
    }
}
