using Microsoft.AspNetCore.Mvc;
using StuMap.Managers;
using StuMap.Models;

namespace StuMap.Controllers
{
    public class RoadmapController(ICourseManager courseRepo, IMaterialTypeManager materialTypeRepo, IMaterialManager materialRepo, IRoadmapManager roadmapRepo, ISpecializationManager specializationRepo ,ICourseRoadmapManager courseRoadmapRepo) : Controller
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
        public IActionResult New()
        {
            var courses = courseRepo.GetAll();
            ViewBag.courses = courses;
            ViewBag.specialization = specializationRepo.GetAll();
            return View();
        }
        public IActionResult AddNew()
        {
            var QString = Request.Query;
            //ContributorId Added manually
            //ContributorId will be changed after auth stuf
            string conId = "E2E368AB-8D20-401B-826A-F591202E3D19";
            var newRoadmap = new Roadmap { Title = QString["RoadmapTitle"], Description = QString["RoadmapDescription"], ContributorId = conId, SpecializationId = int.Parse(QString["specialization"]) };
            var newRoadmapId = roadmapRepo.Insert(newRoadmap);
            List<CourseRoadmap> courseRoadmaps = Request.Query["course"]
                            .ToList().Select(s => new CourseRoadmap { CourseId = int.Parse(s), RoadmapId = newRoadmapId }).ToList();

            courseRoadmapRepo.InsertRange(courseRoadmaps);
            return RedirectToAction("Index");
            //ViewBag.data = courseRoadmaps;
            //return View();

        }
    }
}
