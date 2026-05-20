using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StuMap.Managers;
using StuMap.Models;
using System.Security.Claims;

namespace StuMap.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController(ICourseEnrollmentManager courseEnrollmentManager) : Controller
    {
        public IActionResult GetEnrolledCourses()
        {
            string stuId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var courses = courseEnrollmentManager.GetCoursesForStudent(stuId);
            return View(courses);
        }
        public IActionResult RemoveCourse(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            courseEnrollmentManager.Delete(id, studentId);
            return RedirectToAction("GetEnrolledCourses");
        }
        public IActionResult RemoveCourseFromDetails(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            courseEnrollmentManager.Delete(id, studentId);
            return RedirectToAction("Details", "Course", new { id });
        }
        public IActionResult AddCourseFromDetails(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            courseEnrollmentManager.Insert(new CourseEnrollment { CourseId = id, StudentId = studentId });
            return RedirectToAction("Details", "Course", new { id });
        }

        //public IActionResult EnrollToCourse()
        //{
        //    var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    var courseId = int.Parse(Request.Query["courseId"]);
        //    courseEnrollmentManager.Insert(new CourseEnrollment { CourseId = courseId, StudentId = studentId });
        //    return RedirectToAction("GetEnrolledCourses", new { id = studentId });
        //}

        //public IActionResult Contact()
        //{
        //    return View();
        //}
        //public async Task<IActionResult> SendToUser( string title, string body)
        //{
        //    var tokens = notificationManager.SendNotificationAsync("c1NyIWJlM4GawGMH1xKETV:APA91bEmN0gkwaat7auz02tbFB4KBOtT8YuzDZRmSXxJ1ir9Vn7gaC8QIRAlsnI5zRKLCvQcIxPtKfS_TrOvYah307NblWooDVd5ev5pzLYyFDQ41HRvC1Y", title, body);
        //    return Ok();
        //}
    }
}
