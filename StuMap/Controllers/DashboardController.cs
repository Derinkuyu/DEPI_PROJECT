using Microsoft.AspNetCore.Mvc;
using StuMap.Managers;

namespace StuMap.Controllers
{
    public class DashboardController : Controller
    { 
        //Course
        ICourseManager courseManager;
        IRoadmapManager roadmapManager;

      

        public DashboardController(ICourseManager courseManager, IRoadmapManager roadmapManager)
        {
            this.courseManager = courseManager;
            this.roadmapManager = roadmapManager;
        }

        public IActionResult Index()
        {
            ViewBag.Course = courseManager.GetAll();
            ViewBag.RoadMaps= roadmapManager.GetAll();
            return View();
        }
    }
}
