using Microsoft.AspNetCore.Mvc;

namespace StuMap.API
{
    // API Style: Returns Raw Data
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationAPI : ControllerBase
    {
        public class LoginDto
        {
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto data)
        {
            await Task.Delay(800);
            if (data.Email == "omarmoh2510@gmail.com" && data.Password == "asdasd")
            {
                return Ok(new
                {
                    success = true,
                    url = "/Home/Dashboard",
                    message = "Welcome back!"
                });
            }

            return Unauthorized(new { success = false, message = "Incorrect username or password." });
        }
    }
}
