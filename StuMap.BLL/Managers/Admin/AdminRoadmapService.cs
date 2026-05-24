using Microsoft.EntityFrameworkCore;
using StuMap.BLL.DTO.Admin;
using StuMap.BLL.Models;
using StuMap.BLL.Services.Admin;
using StuMap.DAL.Models;
using StuMap.DAL.Models.Enums;
using StuMap.DAL.Repositories.Interfaces;
using System.Net;

namespace StuMap.BLL.Managers.Admin
{
    public class AdminRoadmapService(
        IGenericRepository<Roadmap> roadmapRepository) : IAdminRoadmapService
    {
        public async Task<ApiResponse> ApproveRoadmap(int id)
        {
            try
            {
                var roadmap = await roadmapRepository.Query().Include(x => x.Courses)
               .FirstOrDefaultAsync(r => r.Id == id);

                if (roadmap != null)
                {
                    roadmap.Status = StatusEnum.Approved;

                    roadmap.ApprovedAt = DateTime.UtcNow;
                    roadmap.RejectionReason = null;

                    if (roadmap.Courses != null)
                    {
                        foreach (var course in roadmap.Courses)
                        {
                            course.Status = StatusEnum.Approved;
                            course.ApprovedAt = DateTime.UtcNow;
                        }
                    }

                    await roadmapRepository.SaveChangesAsync();
                }

                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse.FailureResult("Error");
            }
        }

        public async Task<ApiResponse> DeleteRoadmap(int id)
        {
            try
            {
                var roadmap = await roadmapRepository.GetByIdAsync(id);

                if (roadmap != null)
                {
                    roadmap.IsDeleted = true;
                    await roadmapRepository.SaveChangesAsync();
                }

                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse.FailureResult("Error");
            }
        }


        public async Task<ApiResponse<List<RoadmapRequestDto>>> GetAllRoadmaps()
        {
            try
            {
                List<RoadmapRequestDto> result = await roadmapRepository
                    .Query()
                    .Where(x => !x.IsDeleted)
                    .Include(x => x.Contributor)
                    .Include(x => x.Courses)
                    .Include(x => x.Specialization)
                    .Select(r => new RoadmapRequestDto
                    {
                        Id = r.Id,
                        Name = r.Title,
                        Specialization = r.Specialization != null ? r.Specialization.Name : "No Specialization",
                        ContributorName = r.Contributor != null ? $"{r.Contributor!.FirstName} {r.Contributor!.LastName}" : "Contributor Not Found",
                        Status = r.Status,
                        SubmittedAt = r.SubmittedAt,
                        CoursesCount = r.Courses.Count()
                    }).ToListAsync();

                return ApiResponse<List<RoadmapRequestDto>>.SuccessResult(result);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<List<RoadmapRequestDto>>.FailureResult("Error");
            }
        }


        public async Task<ApiResponse<RoadmapDetailsDto>> GetRoadmapById(int id)
        {
            try
            {
                var roadmap = await roadmapRepository
                    .Query()
                    .Include(r => r.Specialization)
                    .Include(r => r.Contributor)
                    .Include(r => r.Courses).ThenInclude(x => x.Materials)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (roadmap == null)
                    return ApiResponse<RoadmapDetailsDto>.FailureResult("Roadmap not found", HttpStatusCode.NotFound);

                RoadmapDetailsDto result = new()
                {
                    Id = roadmap.Id,
                    Name = roadmap.Title,
                    Description = roadmap.Description,
                    Specialization = roadmap.Specialization == null ? "No Specialization" : roadmap.Specialization.Name,
                    ContributorName = roadmap.Contributor != null ? $"{roadmap.Contributor!.FirstName} {roadmap.Contributor!.LastName}" : "Contributor Not Found",
                    ContributorEmail = roadmap.Contributor != null ? roadmap.Contributor.Email! : "Email Not Found",
                    Status = roadmap.Status,
                    RejectionReason = roadmap.RejectionReason,
                    SubmittedAt = roadmap.SubmittedAt,
                    ApprovedAt = roadmap.ApprovedAt,

                    Courses = [.. roadmap.Courses]
                };

                return ApiResponse<RoadmapDetailsDto>.SuccessResult(result);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<RoadmapDetailsDto>.FailureResult("Error");
            }
        }


        public async Task<ApiResponse> RejectRoadmap(int id, string reason)
        {
            try
            {
                var roadmap = await roadmapRepository.GetByIdAsync(id);

                if (roadmap != null)
                {
                    roadmap.Status = StatusEnum.Rejected;

                    roadmap.RejectionReason = reason;

                    await roadmapRepository.SaveChangesAsync();
                }

                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse.FailureResult("Error");
            }
        }
    }
}
