using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StuMap.Managers;
using StuMap.Models;
using System.Security.Claims;

namespace StuMap.Controllers
{
    public class CourseController(ICourseManager courseRepo, IMaterialTypeManager materialTypeRepo, IMaterialManager materialRepo, ICourseEnrollmentManager courseEnrollmentManager) : Controller
    {
        public IActionResult Index()
        {
            ViewBag.MaterialTypes = materialTypeRepo.GetAll();
            return View(courseRepo.GetAll());
        }

        [Authorize(Roles = "Contributor")]
        public IActionResult SaveCourseAndMaterial()
        {
            var QString = Request.Query;

            //ContributorId Added manually
            //ContributorId will be changed after auth stuf
            string conId = "E2E368AB-8D20-401B-826A-F591202E3D19";
            var newCourse = new Course { Title = QString["CourseTitle"], Description = QString["CourseDescription"], ContributorId = conId };
            var newCourseId = courseRepo.Insert(newCourse);

            List<Material> newMaterials = [];

            for (int i = 1; i <= 5; i++)
            {
                if (!QString[$"MaterialTitle-{i}"].IsNullOrEmpty())
                    newMaterials.Add(new Material { Title = QString[$"MaterialTitle-{i}"][0], Description = QString[$"MaterialDescription-{i}"][0], Url = QString[$"MaterialUrl-{i}"][0], MaterialTypeId = int.Parse(QString[$"MaterialType-{i}"][0]), ContributorId = conId, CourseId = newCourseId });

            }
            materialRepo.InsertRange(newMaterials);
            return RedirectToAction("Index");
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
                    ViewBag.IsEnrolled = courseEnrollmentManager.IsEnrolled(userId, id);
                }
            }
            return View(courseRepo.GetById(id));
        }
    }
}
