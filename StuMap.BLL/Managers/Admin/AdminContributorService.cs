using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StuMap.BLL.DTO.Admin;
using StuMap.BLL.Models;
using StuMap.BLL.Services.Admin;
using StuMap.DAL.Context;
using StuMap.DAL.Models;
using StuMap.DAL.Models.Enums;
using StuMap.DAL.Repositories.Interfaces;
using System.Net;

namespace StuMap.BLL.Managers.Admin
{
    public class AdminContributorService(
        AppDbContext context,
        IGenericRepository<Certificate> certificateRepository,
        UserManager<ApplicationUser> userManager) : IAdminContributorService
    {
        public async Task<ApiResponse> ApproveContributor(string id)
        {
            try
            {
                var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == id);

                if (user != null)
                {
                    user.ContributorStatus = StatusEnum.Approved;

                    await context.SaveChangesAsync();
                }

                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse.FailureResult("Error approving contributor");
            }

        }

        public async Task<ApiResponse<List<ContributorRequestDto>>> GetAllContributors()
        {
            try
            {
                var users = userManager.GetUsersInRoleAsync("Contributor").Result;
                List<ContributorRequestDto> result = [];

                foreach (var u in users)
                {
                    result.Add(new()
                    {
                        Id = u.Id,
                        FullName = $"{u.FirstName} {u.LastName}",
                        Email = u.Email,
                        Specialization = u.Specialization,
                        CertificatePath = (await certificateRepository.Query().FirstOrDefaultAsync(x => x.ContributorId == u.Id))?.Url ?? "No certificates found",
                        Status = u.ContributorStatus,
                        RequestDate = u.RequestDate
                    });
                }

                return ApiResponse<List<ContributorRequestDto>>.SuccessResult(result);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<List<ContributorRequestDto>>.FailureResult("Error getting contributors");
            }

        }

        public async Task<ApiResponse<ContributorDetailsDto>> GetContributorById(string id)
        {
            try
            {
                var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                    return ApiResponse<ContributorDetailsDto>.FailureResult("Contributor not found", statusCode: HttpStatusCode.NotFound);

                var result = new ContributorDetailsDto
                {
                    Id = user.Id,
                    FullName = $"{user.FirstName} {user.LastName}",
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Specialization = user.Specialization,
                    CertificatePath = user.CertificatePath,
                    Status = user.ContributorStatus,
                    RejectionReason = user.RejectionReason,
                    RequestDate = user.RequestDate
                };

                return ApiResponse<ContributorDetailsDto>.SuccessResult(result);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<ContributorDetailsDto>.FailureResult("Error getting contributor");
            }
        }

        public async Task<ApiResponse<int>> GetPendingContributorsCount()
        {
            try
            {
                var result = (await userManager.GetUsersInRoleAsync("Contributor")).Count(x => x.ContributorStatus == StatusEnum.Pending);

                return ApiResponse<int>.SuccessResult(result);
            }
            catch (Exception)
            {
                return ApiResponse<int>.FailureResult("Error");
            }
        }

        public async Task<ApiResponse> RejectContributor(string id, string reason)
        {
            try
            {
                var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == id);

                if (user != null)
                {
                    user.ContributorStatus = StatusEnum.Rejected;
                    user.RejectionReason = reason;

                    await context.SaveChangesAsync();
                }

                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                return ApiResponse.FailureResult("Error rejecting contributor");
            }
        }
    }
}
