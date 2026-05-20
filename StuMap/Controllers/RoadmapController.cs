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
        public IActionResult Details(int id)
        {
            Dictionary<int, string> materialType = materialTypeRepo.GetAll().ToDictionary(x => x.Id, x => x.Title);
            ViewBag.materialType = materialType;
            var roadmap = roadmapRepo.GetById(id);
            return View(roadmap);
        }

    }
}
