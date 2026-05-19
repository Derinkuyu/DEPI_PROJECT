using Microsoft.AspNetCore.Mvc;
using StuMap.Managers;

namespace StuMap.Controllers
{
    public class RoadmapController(ICourseManager courseRepo, IMaterialTypeManager materialTypeRepo, IMaterialManager materialRepo,IRoadmapManager roadmapRepo,ISpecializationManager specializationRepo) : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Specializations = specializationRepo.GetAll();
            var road = roadmapRepo.GetAll();
            return View(road);
        }
    }
}
