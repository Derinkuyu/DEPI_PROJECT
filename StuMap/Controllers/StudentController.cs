using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StuMap.BLL.Services;
using System.Security.Claims;

namespace StuMap.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController(
        ICourseService courseService,
        IRoadmapService roadmapService) : Controller
    {
        public async Task<IActionResult> GetEnrolledCourses()
        {
            var stuId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await courseService.GetEnrolledCourses(stuId);

            if (result.Success)
                return View(result.Data);

            // handle errors
            return View();
        }
        public async Task<IActionResult> RemoveCourse(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await courseService.DropCourse(studentId, id);

            if (result.Success)
                return RedirectToAction("GetEnrolledCourses");

            // handle errors
            return RedirectToAction("GetEnrolledCourses");

        }
        public async Task<IActionResult> RemoveCourseFromDetails(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await courseService.DropCourse(studentId, id);

            if (result.Success)
                return RedirectToAction("Details", "Course", new { id });

            // handle errors
            return RedirectToAction("Details", "Course", new { id });
        }

        public async Task<IActionResult> AddCourseFromDetails(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await courseService.EnrollCourse(studentId, id);

            if (result.Success)
                return RedirectToAction("Details", "Course", new { id });

            // handle errors
            return RedirectToAction("Details", "Course", new { id });
        }

        public async Task<IActionResult> GetEnrolledRoadmaps()
        {
            var stuId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await roadmapService.GetEnrolledRoadmaps(stuId);

            if (result.Success)
                return View(result.Data);

            // handle errors
            return View();
        }
        public async Task<IActionResult> RemoveRoadmap(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await roadmapService.DropRoadmap(studentId, id);

            if (result.Success)
                return RedirectToAction("GetEnrolledRoadmaps");

            // handle errors
            return RedirectToAction("GetEnrolledRoadmaps");
        }
        public async Task<IActionResult> RemoveRoadmapFromDetails(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await roadmapService.DropRoadmap(studentId, id);

            if (result.Success)
                return RedirectToAction("Details", "Roadmap", new { id });

            // handle errors
            return RedirectToAction("Details", "Roadmap", new { id });
        }
        public async Task<IActionResult> AddRoadmapFromDetails(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await roadmapService.EnrollRoadmap(studentId, id);

            if (result.Success)
                return RedirectToAction("Details", "Roadmap", new { id });

            // handle errors
            return RedirectToAction("Details", "Roadmap", new { id });
        }
    }
}
