using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StuMap.BLL.Services;
using StuMap.DAL.Models;
using System.Security.Claims;

namespace StuMap.Controllers
{
    public class RoadmapController(
        ICourseService courseService,
        IMaterialTypeService materialTypeService,
        IContributorService contributorService,
        IRoadmapService roadmapService,
        ISpecializationService specializationService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var specializations = await specializationService.GetAll();
            if (specializations.Success)
            {
                ViewBag.Specializations = specializations.Data;
            }

            var approved = await contributorService.IsApproved(User);
            if (approved.Success)
            {
                ViewBag.Approved = approved.Data;
            }
            

            var roadmaps = await roadmapService.GetApprovedRoadmaps();
            if (roadmaps.Success)
            {
                return View(roadmaps.Data);
            }
            else
            {
                // handle error
            }

            return View();
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

                    var isEnrolled = await roadmapService.IsEnrolledInRoadmap(userId, id);
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
            var materialTypes = await materialTypeService.GetAll();
            if (materialTypes.Success)
            {
                ViewBag.materialType = materialTypes.Data!.ToDictionary(x => x.Id, x => x.Title);
            }

            var roadmap = await roadmapService.GetRoadmap(id);
            if (roadmap.Success)
            {
                return View(roadmap.Data);
            }
            else
            {
                // handle error
            }

            return View();
        }
        [Authorize(Roles = "Contributor")]
        // todo: add policy to check if we are approved
        public async Task<IActionResult> New()
        {
            var courses = await courseService.GetApprovedCourses();
            if (courses.Success)
            {
                ViewBag.courses = courses.Data;
            }

            var specialization = await specializationService.GetAll();
            if (specialization.Success)
            {
                ViewBag.specialization = specialization.Data;
            }


            return View();
        }
        // todo: create a dto for this
        // todo: add policy to check if we are approved
        [Authorize(Roles = "Contributor")]
        public async Task<IActionResult> AddNew()
        {
            var QString = Request.Query;
            //ContributorId Added manually
            //ContributorId will be changed after auth stuf
            string conId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newRoadmap = new Roadmap { Title = QString["RoadmapTitle"], Description = QString["RoadmapDescription"], ContributorId = conId, SpecializationId = int.Parse(QString["specialization"]) };


            var result = await roadmapService.SaveRoadmap(newRoadmap, [.. Request.Query["course"].ToList().Select(int.Parse!)]);

            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // handle error
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> MyRoadmaps()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRoadmaps = await roadmapService.GetMyRoadmaps(userId);
            if (userRoadmaps.Success)
            {
                return View(userRoadmaps.Data);
            }
            else
            {
                // handle errors
            }
            return View();

        }
    }
}
