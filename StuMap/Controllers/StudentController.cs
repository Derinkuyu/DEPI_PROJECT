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
        ICourseEnrollmentManager courseEnrollmentManager;
        INotificationManager notificationManager;
        IContactManager contactManager;
        UserManager<ApplicationUser> userManager;
        public StudentController(ICourseEnrollmentManager courseEnrollmentManager , INotificationManager notificationManager , IContactManager contactManager , UserManager<ApplicationUser> userManager)
        {
            this.courseEnrollmentManager = courseEnrollmentManager;
            this.notificationManager = notificationManager;
            this.contactManager = contactManager;
            this.userManager = userManager;
        }
        public IActionResult GetEnrolledCourses()
        {
            //StudentId will be changed after auth stuf
            var stuId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var courses = courseEnrollmentManager.GetCoursesForStudent(stuId);
            return View(courses);
        }
        public IActionResult RemoveCourse(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            courseEnrollmentManager.Delete(id, studentId);
            return RedirectToAction("GetEnrolledCourses", new { id = studentId });
        }
        public IActionResult RemoveCourseFromDetails(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            courseEnrollmentManager.Delete(id, studentId);
            return RedirectToAction("Details" , "Course" , new { id = id });
        }
        public IActionResult AddCourseFromDetails(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            courseEnrollmentManager.Insert(new CourseEnrollment { CourseId = id, StudentId = studentId });
            return RedirectToAction("Details", "Course", new { id = id });
        }

    }
}
