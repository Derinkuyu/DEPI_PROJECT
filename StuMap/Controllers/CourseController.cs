using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StuMap.Managers;
using StuMap.Models;
using StuMap.Models.Enums;
using System.Security.Claims;

namespace StuMap.Controllers
{
    public class CourseController(ICourseManager courseRepo,
        IMaterialTypeManager materialTypeRepo,
        IMaterialManager materialRepo,
        UserManager<ApplicationUser> userManager,
        ICourseEnrollmentManager courseEnrollmentManager) : Controller
    {
        public IActionResult Index()
        {
            ViewBag.MaterialTypes = materialTypeRepo.GetAll() ;
            ViewBag.Approved = User.IsInRole("Contributor") &&
            userManager.GetUserAsync(User).Result?.ContributorStatus == ContributorStatus.Approved;

            return View(courseRepo.GetAll().Where(x => x.Status == CourseStatus.Approved).ToList());
        }

        [Authorize(Roles = "Contributor")]
        public IActionResult SaveCourseAndMaterial()
        {
            var QString = Request.Query;

            //ContributorId Added manually
            //ContributorId will be changed after auth stuf
            string conId = User.FindFirstValue(ClaimTypes.NameIdentifier);
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
        public IActionResult MyCourses()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userCourses = courseRepo.GetAll().Where(x => x.ContributorId == userId).ToList();
            return View(userCourses);
        }
    }
}
