using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StuMap.Managers;
using StuMap.Models;
using System.Security.Claims;

namespace StuMap.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        ICourseEnrollmentManager courseEnrollment;
        IRoadmapEnrollmentManager roadmapEnrollment;
        public StudentController(ICourseEnrollmentManager courseEnrollmentManager, IRoadmapEnrollmentManager roadmapEnrollmentManager)
        {
            this.courseEnrollment = courseEnrollmentManager;
            this.roadmapEnrollment = roadmapEnrollmentManager;
        }
        public IActionResult GetEnrolledCourses()
        {
            var stuId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var courses = courseEnrollment.GetCoursesForStudent(stuId);
            return View(courses);
        }
        public IActionResult RemoveCourse(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            courseEnrollment.Delete(id, studentId);
            return RedirectToAction("GetEnrolledCourses", new { id = studentId });
        }
        public IActionResult RemoveCourseFromDetails(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            courseEnrollment.Delete(id, studentId);
            return RedirectToAction("Details", "Course", new { id = id });
        }
        public IActionResult AddCourseFromDetails(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            courseEnrollment.Insert(new CourseEnrollment { CourseId = id, StudentId = studentId });
            return RedirectToAction("Details", "Course", new { id = id });
        }
        public IActionResult GetEnrolledRoadmaps()
        {
            var stuId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var roadmaps = roadmapEnrollment.GetRoadmapsForStudent(stuId);
            return View(roadmaps);
        }
        public IActionResult RemoveRoadmap(int id)     
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            roadmapEnrollment.Delete(id, studentId);
            return RedirectToAction("GetEnrolledRoadmaps", new { id = studentId });
        }
        public IActionResult RemoveRoadmapFromDetails(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            roadmapEnrollment.Delete(id, studentId);
            return RedirectToAction("Details", "Roadmap", new { id = id });
        }
        public IActionResult AddRoadmapFromDetails(int id)
        {
            var stuId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            roadmapEnrollment.Insert(new RoadmapEnrollment { RoadmapId = id, StudentId = stuId });
            return RedirectToAction("Details", "Roadmap", new { id = id });
        }
    }
}
