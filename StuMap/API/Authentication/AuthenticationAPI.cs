using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StuMap.DTO.Authentication;
using StuMap.Services.Authentication;

namespace StuMap.API
{
    // API Style: Returns Raw Data
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationAPI(
        IAuthenticationService authenticationService) : ControllerBase
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
                return BadRequest();

            var (success, message) = await authenticationService.Login(data);

            if (success)
            {
                return Ok(new { success, message });
            }
            return Unauthorized(new { success, message });
        }


        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupDto signupDto)
        {
            Console.WriteLine($"Sign Up Request From : {signupDto.Email}");
            Console.WriteLine($"DoB: {signupDto.DateOfBirth}");

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
                return BadRequest(ModelState);
            }

            if (await authenticationService.Signup(signupDto))
                return Ok(new
                {
                    success = true
                });

            return BadRequest();
        }
    }
}
