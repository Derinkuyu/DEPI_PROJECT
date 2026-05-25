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
    public class AdminCourseService(
        IGenericRepository<Course> courseRepository) : IAdminCourseService
    {
        public async Task<ApiResponse> ApproveCourse(int id)
        {
            try
            {
                var course = await courseRepository.GetByIdAsync(id);

                if (course != null)
                {
                    course.Status = StatusEnum.Approved;

                    course.ApprovedAt = DateTime.UtcNow;
                    course.RejectionReason = null;


                    await courseRepository.SaveChangesAsync();
                }

                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse.FailureResult("Error");
            }
        }

        public async Task<ApiResponse> DeleteCourse(int id)
        {
            try
            {
                var course = await courseRepository.GetByIdAsync(id);

                if (course != null)
                {
                    course.IsDeleted = true;
                    await courseRepository.SaveChangesAsync();
                }

                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse.FailureResult("Error");
            }
        }


        public async Task<ApiResponse<List<CourseRequestDto>>> GetAllCourseRequests()
        {
            try
            {
                List<CourseRequestDto> result = await courseRepository
                    .Query()
                    .Where(x => !x.IsDeleted)
                    .Include(x => x.Contributor)
                    .Include(x => x.Materials)
                    .Select(c => new CourseRequestDto
                    {
                        Id = c.Id,

                        Title = c.Title,

                        ContributorName =
                        c.Contributor != null
                            ? $"{c.Contributor.FirstName} {c.Contributor.LastName}"
                            : "Unknown Contributor",

                        MaterialsCount = c.Materials.Count(),

                        Status = c.Status,

                        SubmittedAt = c.SubmittedAt

                    }).ToListAsync();

                return ApiResponse<List<CourseRequestDto>>.SuccessResult(result);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<List<CourseRequestDto>>.FailureResult("Error");
            }
        }

        public async Task<ApiResponse<List<Course>>> GetAllCourses()
        {
            try
            {
                List<Course> result = await courseRepository
                    .Query()
                    .Include(c => c.Contributor)
                    .Include(c => c.Materials)
                    .ThenInclude(m => m.MaterialType)
                    .ToListAsync();

                return ApiResponse<List<Course>>.SuccessResult(result);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<List<Course>>.FailureResult("Error");
            }
        }

        public async Task<ApiResponse<CourseDetailsDto>> GetCourseById(int id)
        {
            try
            {
                var course = await courseRepository
                    .Query()
                    .Include(c => c.Materials)
                    .ThenInclude(c => c.MaterialType)
                    .Include(c => c.Contributor)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (course == null)
                    return ApiResponse<CourseDetailsDto>.FailureResult("Course not found", HttpStatusCode.NotFound);


                CourseDetailsDto result = new()
                {
                    Id = course.Id,
                    Title = course.Title,
                    Description = course.Description,

                    ContributorName =
                    course.Contributor != null ?
                    $"{course.Contributor.FirstName} {course.Contributor.LastName}"
                    : "Unknown Contributor",

                    ContributorEmail = course.Contributor?.Email ?? "No Email",
                    Status = course.Status,
                    RejectionReason = course.RejectionReason,
                    DateCreated = course.DateCreated,
                    SubmittedAt = course.SubmittedAt,
                    ApprovedAt = course.ApprovedAt,
                    MaterialsCount = course.Materials.Count,
                    Materials = course.Materials
                    .Select(m => new MaterialDto
                    {
                        Id = m.Id,
                        Title = m.Title,
                        Description = m.Description,
                        Url = m.Url,
                        MaterialType = m.MaterialType?.Title ?? string.Empty
                    })
                };

                return ApiResponse<CourseDetailsDto>.SuccessResult(result);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<CourseDetailsDto>.FailureResult("Error");
            }
        }


        public async Task<ApiResponse> RejectCourse(int id, string reason)
        {
            try
            {
                var course = await courseRepository.GetByIdAsync(id);

                if (course != null)
                {
                    course.Status = StatusEnum.Rejected;

                    course.RejectionReason = reason;

                    await courseRepository.SaveChangesAsync();
                }

                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse.FailureResult("Error");
            }
        }

        public async Task<ApiResponse<int>> GetPendingCoursesCount()
        {
            try
            {
                var result = await courseRepository.Query().CountAsync(x => x.Status == StatusEnum.Pending ||
                        x.Status == StatusEnum.UpdatedPending);

                return ApiResponse<int>.SuccessResult(result);
            }
            catch (Exception)
            {
                return ApiResponse<int>.FailureResult("Error");
            }
        }
    }
}
