using Microsoft.AspNetCore.Identity;
using StuMap.BLL.Models;
using StuMap.BLL.Services;
using StuMap.DAL.Models;
using StuMap.DAL.Models.Enums;
using System.Net;
using System.Security.Claims;

namespace StuMap.BLL.Managers
{
    public class ContributorService(
        UserManager<ApplicationUser> userManager) : IContributorService
    {

        public async Task<ApiResponse<bool>> IsApproved(ClaimsPrincipal user)
        {
            try
            {

                var appUser = await userManager.GetUserAsync(user);
                if (appUser == null)
                    return ApiResponse<bool>.FailureResult("User Not Found", HttpStatusCode.NotFound);

                var approved = user.IsInRole("Contributor") && appUser.ContributorStatus == StatusEnum.Approved;

                return ApiResponse<bool>.SuccessResult(approved);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<bool>.FailureResult("Error");
            }
        }
    }
}
