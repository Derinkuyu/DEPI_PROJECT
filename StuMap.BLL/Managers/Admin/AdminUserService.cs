using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StuMap.BLL.DTO.Admin;
using StuMap.BLL.Models;
using StuMap.BLL.Services.Admin;
using StuMap.DAL.Context;
using StuMap.DAL.Models;
using System.Net;

namespace StuMap.BLL.Managers.Admin
{
    public class AdminUserService(
        AppDbContext context,
        UserManager<ApplicationUser> userManager) : IAdminUserService
    {

        public async Task<ApiResponse<List<UserDto>>> GetAllUsers()
        {
            try
            {
                var users = await userManager.Users.ToListAsync();
                List<UserDto> result = [];
                foreach (var user in users)
                {
                    result.Add(new()
                    {
                        Id = user.Id,
                        FullName = $"{user.FirstName} {user.LastName}",
                        Email = user.Email ?? "No email found",
                        Role = (await userManager.GetRolesAsync(user)).FirstOrDefault() ?? "User",
                        IsBlocked = user.IsBlocked,
                        CreatedAt = user.CreatedAt
                    });
                }

                return ApiResponse<List<UserDto>>.SuccessResult(result);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<List<UserDto>>.FailureResult("Error getting users");
            }

        }

        public async Task<ApiResponse<UserDetailsDto>> GetUserDetails(string id)
        {
            try
            {
                var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user == null) return ApiResponse<UserDetailsDto>.FailureResult("User not found.", statusCode: HttpStatusCode.NotFound);

                var userDto = new UserDetailsDto
                {
                    Id = user.Id,
                    FullName = $"{user.FirstName} {user.LastName}",
                    Email = user.Email ?? "Email not found",
                    PhoneNumber = user.PhoneNumber ?? "Phone number not found",
                    Role = (await userManager.GetRolesAsync(user)).FirstOrDefault() ?? "User",
                    IsBlocked = user.IsBlocked,
                    CreatedAt = user.CreatedAt
                };

                return ApiResponse<UserDetailsDto>.SuccessResult(userDto);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<UserDetailsDto>.FailureResult("Error getting user");
            }
        }

        public async Task<ApiResponse> DeleteUser(string id)
        {
            try
            {
                var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user != null)
                {
                    await userManager.DeleteAsync(user);
                }

                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                return ApiResponse.FailureResult("Error deleting user");
            }

        }

        public async Task<ApiResponse> BlockUser(string id)
        {
            try
            {
                var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user != null)
                {
                    user.IsBlocked = true;
                    await context.SaveChangesAsync();
                }

                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                return ApiResponse.FailureResult("Error blocking user");
            }
        }

        public async Task<ApiResponse> UnblockUser(string id)
        {
            try
            {
                var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user != null)
                {
                    user.IsBlocked = false;
                    await context.SaveChangesAsync();
                }

                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                return ApiResponse.FailureResult("Error unblocking user");
            }
        }

        public async Task<ApiResponse<int>> CountUsersInRole(string role)
        {
            try
            {
                var user = (await userManager.GetUsersInRoleAsync(role)).Count;

                return ApiResponse<int>.SuccessResult(user);
            }
            catch (Exception)
            {
                return ApiResponse<int>.FailureResult("Error");
            }
        }
    }
}
