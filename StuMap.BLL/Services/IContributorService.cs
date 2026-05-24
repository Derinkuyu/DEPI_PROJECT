using StuMap.BLL.Models;
using System.Security.Claims;

namespace StuMap.BLL.Services
{
    public interface IContributorService
    {
        public Task<ApiResponse<bool>> IsApproved(ClaimsPrincipal user);
    }
}
