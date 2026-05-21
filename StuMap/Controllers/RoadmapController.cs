using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StuMap.Managers;
using StuMap.Models;
using StuMap.Models.Enums;
using System.Security.Claims;

namespace StuMap.Controllers
{
    public class RoadmapController(ICourseManager courseRepo, IMaterialTypeManager materialTypeRepo, IMaterialManager materialRepo, IRoadmapManager roadmapRepo, ISpecializationManager specializationRepo, ICourseRoadmapManager courseRoadmapRepo, IRoadmapEnrollmentManager roadmapEnrollment) : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Specializations = specializationRepo.GetAll();
            var road = roadmapRepo.GetAll().Where(x=>x.Status==RoadmapStatus.Approved).ToList();
            return View(road);
        }
        public IActionResult Details(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                bool isStudent = User.IsInRole("Student");
                if (isStudent)
                {
                    ViewBag.IsStudent = true;
                    ViewBag.IsEnrolled = roadmapEnrollment.IsEnrolled(userId, id);
                }
            }
            Dictionary<int, string> materialType = materialTypeRepo.GetAll().ToDictionary(x => x.Id, x => x.Title);
            ViewBag.materialType = materialType;
            var roadmap = roadmapRepo.GetById(id);
            return View(roadmap);
        }
        [Authorize(Roles = "Contributor")]
        public IActionResult New()
        {
            var courses = courseRepo.GetAll().Where(x => x.Status == CourseStatus.Approved).ToList();
            ViewBag.courses = courses;
            ViewBag.specialization = specializationRepo.GetAll();
            return View();
        }
        [Authorize(Roles = "Contributor")]
        public IActionResult AddNew()
        {
            var QString = Request.Query;
            //ContributorId Added manually
            //ContributorId will be changed after auth stuf
            string conId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newRoadmap = new Roadmap { Title = QString["RoadmapTitle"], Description = QString["RoadmapDescription"], ContributorId = conId, SpecializationId = int.Parse(QString["specialization"]) };
            var newRoadmapId = roadmapRepo.Insert(newRoadmap);
            List<CourseRoadmap> courseRoadmaps = Request.Query["course"]
                            .ToList().Select(s => new CourseRoadmap { CourseId = int.Parse(s), RoadmapId = newRoadmapId }).ToList();

            courseRoadmapRepo.InsertRange(courseRoadmaps);
            return RedirectToAction("Index");
            //ViewBag.data = courseRoadmaps;
            //return View();

        }
        public IActionResult MyRoadmaps()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRoadmaps = roadmapRepo.GetAll().Where(x => x.ContributorId == userId).ToList();
            return View(userRoadmaps);

        }
    }
}
