using StuMap.DTO.Authentication;

namespace StuMap.Services.Authentication
{
    public interface IAuthenticationService
    {
        public Task<(bool success, string[] messages)> Signup(SignupDto signupDto);
        public Task<(bool success, string message)> Login(LoginDto loginDto);

        public Task Logout();


        public Task Test();
    }
}
