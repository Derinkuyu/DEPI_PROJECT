using Microsoft.AspNetCore.Mvc;

namespace StuMap.Controllers
{
    public class AuthenticationController : Controller
    {
        [Route("login")]
        public IActionResult Login()
        {
            // to do: check if the user is already logged in, if so, redirect to home page
            return View("login");
        }

        // todo: implement register page
        [Route("register")]
        public IActionResult Register()
        {
            return Redirect("/Home");
        }
    }
}
