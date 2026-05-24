using StuMap.BLL.DTO.Authentication;
using StuMap.BLL.Models;

namespace StuMap.BLL.Services.Authentication
{
    public interface IAuthenticationService
    {
        public Task<ApiResponse> Signup(SignupDto signupDto);
        public Task<ApiResponse> Login(LoginDto loginDto);

        public Task<ApiResponse> Logout();

    }
}
