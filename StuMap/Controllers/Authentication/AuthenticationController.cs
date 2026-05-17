using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StuMap.Services.Authentication;

namespace StuMap.Controllers
{
    public class AuthenticationController(
        IAuthenticationService authenticationService) : Controller
    {
        [Route("login")]
        public IActionResult Login()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("Login");
        }
        [Route("register")]
        public IActionResult Register()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }


            return View("Register");
        }
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await authenticationService.Logout();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [Route("Test")]
        public IActionResult Test()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
