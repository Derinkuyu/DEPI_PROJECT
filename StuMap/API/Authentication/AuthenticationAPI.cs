using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StuMap.BLL.DTO.Authentication;
using StuMap.BLL.Services.Authentication;
using StuMap.DAL.Models;

namespace StuMap.API
{
    // API Style: Returns Raw Data
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationAPI(
        IAuthenticationService authenticationService, /*INotificationManager notificationManager */ UserManager<ApplicationUser> userManager) : ControllerBase
    {

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await authenticationService.Logout();

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto data)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                               .Select(e => e.ErrorMessage);

                string errMsg = "Login Failed.";
                foreach (var error in errors)
                {
                    errMsg += $"\n{error}";
                }
                return BadRequest(new { success = false, message = errMsg });
            }

            var result = await authenticationService.Login(data);
            if (result.Success)
            {
                if (!string.IsNullOrEmpty(data.DeviceToken))
                {
                    var user = await userManager.FindByEmailAsync(data.Email);
                    //notificationManager.AddDeviceToken(user.Id, data.DeviceToken);
                }

                return Ok(new { success = result.Success, message = result.Message });
            }

            return Unauthorized(new { result.Success, result.Message });
        }


        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupDto signupDto)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine($"Reporting Errors:");
                // Extract every error message from the ModelState dictionary
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                               .Select(e => e.ErrorMessage);


                foreach (var error in errors)
                {
                    Console.WriteLine($"[MODELSTATE ERROR] {error}");
                }
                return BadRequest(new
                {
                    success = false,
                    messages = errors.ToArray(),
                });
            }

            var result = await authenticationService.Signup(signupDto);


            if (result.Success)
                return Ok(new
                {
                    success = result.Success,
                    messages = new List<string> { result.Message! }
                });
            else
            {
                return BadRequest(new
                {
                    success = result.Success,
                    messages = result.Errors
                });
            }
        }
    }
}
