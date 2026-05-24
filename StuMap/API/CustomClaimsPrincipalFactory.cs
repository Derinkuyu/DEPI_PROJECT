using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using StuMap.DAL.Models;
namespace StuMap.API
{
    public class CustomClaimsPrincipalFactory(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<IdentityOptions> optionsAccessor) : 
        UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>(userManager, roleManager, optionsAccessor)
    {
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("FirstName", user.FirstName!));
            identity.AddClaim(new Claim("LastName", user.LastName!));

            return identity;
        }
    }
}