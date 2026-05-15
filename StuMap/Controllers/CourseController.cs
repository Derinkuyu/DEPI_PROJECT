using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StuMap.Managers;
using StuMap.Models;

namespace StuMap.Controllers
{
    public class CourseController : Controller
    {
        ICourseManager courseRepo;
        IMaterialTypeManager materialTypeRepo;
        IMaterialManager materialRepo;
        public CourseController(ICourseManager courseRepo,IMaterialTypeManager materialTypeRepo,IMaterialManager materialRepo)
        {
            this.courseRepo = courseRepo;
            this.materialTypeRepo = materialTypeRepo;
            this.materialRepo = materialRepo;
        }
        public IActionResult Index()
        {
            ViewBag.MaterialTypes= materialTypeRepo.GetAll();
            return View(courseRepo.GetAll());
        }

        public IActionResult SaveCourseAndMaterial()
        {
            var QString = Request.Query;

            //ContributorId Added manually

            //ContributorId will be changed after auth stuf
            var newCourse = new Course{ Title = QString["CourseTitle"], Description = QString["CourseDescription"], ContributorId = "1"};
            var newCourseId=courseRepo.Insert(newCourse);

            List<Material> newMaterials = [];

            for (int i = 1; i <= 5; i++)
            {
                if (!QString[$"MaterialTitle-{i}"].IsNullOrEmpty())
                    newMaterials.Add(new Material { Title = QString[$"MaterialTitle-{i}"][0], Description = QString[$"MaterialDescription-{i}"][0], Url = QString[$"MaterialUrl-{i}"][0], MaterialTypeId = int.Parse(QString[$"MaterialType-{i}"][0]), ContributorId = "1", CourseId = newCourseId });

            }
            materialRepo.InsertRange(newMaterials);
            //foreach (var queryParam in Request.Query)
            //{
            //    var key = queryParam.Key;
            //    var value = queryParam.Value; // This is a StringValues object (can hold multiple values for one key)

            //}
           
            return RedirectToAction("Index");
        }

    }
}
