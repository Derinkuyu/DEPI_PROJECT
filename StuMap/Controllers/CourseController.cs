using Microsoft.AspNetCore.Mvc;
using StuMap.Managers;

namespace StuMap.Controllers
{
    public class CourseController : Controller
    {
        ICourseManager courseRepo;
        public CourseController(ICourseManager courseRepo)
        {
            this.courseRepo = courseRepo;
        }
        public IActionResult Index()
        {
            return View(courseRepo.GetAll());
        }

    }
}
