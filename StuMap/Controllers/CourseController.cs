using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StuMap.BLL.Services;
using StuMap.DAL.Models;
using System.Security.Claims;

namespace StuMap.Controllers
{
    public class CourseController(
        ICourseService courseService,
        IContributorService contributorService,
        IMaterialTypeService materialTypeService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var materials = await materialTypeService.GetAll();
            if (materials.Success)
            {
                ViewBag.MaterialTypes = materials.Data;
            }
            else
            {
                //handle error
            }


            var approved = await contributorService.IsApproved(User);
            if (approved.Success)
            {
                ViewBag.Approved = approved.Data;
            }
            else
            {
                //handle error
            }

            var courses = await courseService.GetApprovedCourses();
            if (approved.Success)
            {
                return View(courses.Data);
            }
            else
            {
                //handle error
            }

            return View();
        }

        [Authorize(Roles = "Contributor")]
        // todo: add policy to check if we are approved
        public async Task<IActionResult> SaveCourseAndMaterial()
        {
            // todo: create a dto for this and move the logic to the service

            var QString = Request.Query;

            //ContributorId Added manually
            //ContributorId will be changed after auth stuf
            string conId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newCourse = new Course { Title = QString["CourseTitle"], Description = QString["CourseDescription"], ContributorId = conId };

            List<Material> newMaterials = [];

            for (int i = 1; i <= 5; i++)
            {
                if (!QString[$"MaterialTitle-{i}"].IsNullOrEmpty())
                    newMaterials.Add(new Material { Title = QString[$"MaterialTitle-{i}"][0], Description = QString[$"MaterialDescription-{i}"][0], Url = QString[$"MaterialUrl-{i}"][0], MaterialTypeId = int.Parse(QString[$"MaterialType-{i}"][0]), ContributorId = conId });

            }
            var result = await courseService.SaveCourseAndMaterials(newCourse, newMaterials);

            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                //handle error
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                bool isStudent = User.IsInRole("Student");
                if (isStudent)
                {
                    ViewBag.IsStudent = true;
                    var isEnrolled = await courseService.IsEnrolledInCourse(userId, id);
                    if (isEnrolled.Success)
                    {
                        ViewBag.IsEnrolled = isEnrolled.Data;
                    }
                    else
                    {
                        ViewBag.IsEnrolled = false;
                    }
                }
            }
            var result = await courseService.GetCourse(id);
            if (result.Success)
            {
                return View(result.Data);

            }
            else
            {
                //handle error
            }
            return View();
        }
        public async Task<IActionResult> MyCourses()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await courseService.GetMyCourses(userId);

            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                //handle error
            }
            return View();
        }
    }
}
