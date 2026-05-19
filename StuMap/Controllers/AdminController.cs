using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StuMap.Managers;

namespace StuMap.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        /*------------------------------------------------------------------------------------*/
        private readonly IUserManager _userManager;
        private readonly IContributorManager _contributorManager;
        /*------------------------------------------------------------------------------------*/
        public AdminController(IUserManager userManager, IContributorManager contributorManager)
        {
            _userManager = userManager;
            _contributorManager = contributorManager;
        }
        /*------------------------------------------------------------------------------------*/
        /////////// Users Management
        /*------------------------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Index()
        {
            var users = _userManager.GetAll();
            return View(users);
        }
        /*------------------------------------------------------------------------------------*/
        [HttpGet]

        public IActionResult Details(string id)
        {
            var user = _userManager.GetById(id);

            return View(user);
        }
        /*------------------------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Delete(string id)
        {
            _userManager.Delete(id);

            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------------------------*/
        public IActionResult Block(string id)
        {
            _userManager.Block(id);

            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------------------------*/
        public IActionResult UnBlock(string id)
        {
            _userManager.Unblock(id);

            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------------------------*/
        /////////// Contributors Management
        /*------------------------------------------------------------------------------------*/
        public IActionResult ContributorRequests()
        {
            var requests = _contributorManager.GetPendingRequests();

            return View(requests);
        }
        /*------------------------------------------------------------------------------------*/
        public IActionResult ContributorDetails(string id)
        {
            var contributor = _contributorManager.GetContributorById(id);

            return View(contributor);
        }
        /*------------------------------------------------------------------------------------*/
        public IActionResult ApproveContributor(string id)
        {
            _contributorManager.ApproveContributor(id);

            return RedirectToAction("ContributorRequests");
        }
        /*------------------------------------------------------------------------------------*/
        [HttpPost]
        public IActionResult RejectContributor(string id, string reason)
        {
            _contributorManager.RejectContributor(id, reason);

            return RedirectToAction("ContributorRequests");
        }
        /*------------------------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------*/
    }
}
