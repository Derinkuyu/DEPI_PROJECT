using Microsoft.AspNetCore.Mvc;
using StuMap.Managers;
using StuMap.Models;
using System.Security.Claims;

namespace StuMap.Controllers
{
    public class StudentController : Controller
    {
        ICourseEnrollmentManager courseEnrollmentManager;
        //INotificationManager notificationManager;
        public StudentController(ICourseEnrollmentManager courseEnrollmentManager )//, INotificationManager notificationManager)
        {
            this.courseEnrollmentManager = courseEnrollmentManager;
            //this.notificationManager = notificationManager;
        }
        public IActionResult GetEnrolledCourses()
        {
            //StudentId will be changed after auth stuf
            var stuId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(string.IsNullOrEmpty(stuId ))
            {
                //  I should go to login page
                return RedirectToAction("Login", "Authentication");
            }
            var courses = courseEnrollmentManager.GetCoursesForStudent(stuId);
            return View(courses);
        }
        public IActionResult RemoveCourse(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (studentId == null)
            {
                //  I should go to login page
                return RedirectToAction("Login", "Authentication");
            }
            courseEnrollmentManager.Delete(id, studentId);
            return RedirectToAction("GetEnrolledCourses", new { id = studentId });
        }
        public IActionResult RemoveCourseFromDetails(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (studentId == null)
            {
                //  I should go to login page
                return RedirectToAction("Login", "Authentication");
            }
            courseEnrollmentManager.Delete(id, studentId);
            return RedirectToAction("Details" , "Course" , new { id = id });
        }
        public IActionResult AddCourseFromDetails(int id)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (studentId == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            courseEnrollmentManager.Insert(new CourseEnrollment { CourseId = id, StudentId = studentId });
            return RedirectToAction("Details", "Course", new { id = id });
        }
        public IActionResult EnrollToCourse()
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (studentId == null)
            {
                //  I should go to login page
                return RedirectToAction("Login", "Authentication");
            }
            var courseId = int.Parse(Request.Query["courseId"]);
            courseEnrollmentManager.Insert(new CourseEnrollment { CourseId = courseId, StudentId = studentId });
            return RedirectToAction("GetEnrolledCourses", new { id = studentId });
        }

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
