using Microsoft.EntityFrameworkCore;
using StuMap.BLL.Models;
using StuMap.BLL.Services;
using StuMap.DAL.Models;
using StuMap.DAL.Models.Enums;
using StuMap.DAL.Repositories.Interfaces;
using System.Net;

namespace StuMap.BLL.Managers
{
    public class RoadmapService(
        IGenericRepository<Roadmap> roadmapRepo,
        IGenericRepository<Course> courseRepo,
        IGenericRepository<RoadmapEnrollment> enrollmentRepo) : IRoadmapService
    {
        public async Task<ApiResponse<List<Roadmap>>> GetApprovedRoadmaps()
        {
            try
            {
                var result = await roadmapRepo
                    .Query()
                    .Where(x => x.Status == StatusEnum.Approved)
                    .Include(r => r.Specialization)
                    .Include(r => r.Contributor)
                    .Include(r => r.Courses)
                    .ThenInclude(c => c.Materials)
                    .ThenInclude(c => c.Contributor)
                    .ToListAsync();


                return ApiResponse<List<Roadmap>>.SuccessResult([.. result]);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<List<Roadmap>>.FailureResult("Error");
            }
        }

        public async Task<ApiResponse<Roadmap>> GetRoadmap(int id)
        {
            try
            {
                var result = await roadmapRepo
                    .Query()
                    .Include(r => r.Specialization)
                    .Include(r => r.Contributor)
                    .Include(r => r.Courses)
                    .ThenInclude(c => c.Materials)
                    .ThenInclude(c => c.Contributor)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (result == null)
                    return ApiResponse<Roadmap>.FailureResult("Not found", HttpStatusCode.NotFound);


                return ApiResponse<Roadmap>.SuccessResult(result);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<Roadmap>.FailureResult("Error");
            }
        }

        public async Task<ApiResponse<List<Roadmap>>> GetMyRoadmaps(string? contributorId)
        {
            try
            {
                var result = await roadmapRepo
                    .Query()
                    .Include(r => r.Specialization)
                    .Include(r => r.Contributor)
                    .Include(r => r.Courses)
                    .ThenInclude(c => c.Materials)
                    .ThenInclude(c => c.Contributor)
                    .Where(x => x.ContributorId == contributorId).ToListAsync();


                return ApiResponse<List<Roadmap>>.SuccessResult(result);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<List<Roadmap>>.FailureResult("Error");
            }
        }

        public async Task<ApiResponse<bool>> IsEnrolledInRoadmap(string? userId, int roadmapId)
        {
            try
            {
                var result = await enrollmentRepo
                    .Query()
                    .AnyAsync(e => e.StudentId == userId && e.RoadmapId == roadmapId);

                return ApiResponse<bool>.SuccessResult(result);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<bool>.FailureResult("Error");
            }
        }

        public async Task<ApiResponse> SaveRoadmap(Roadmap roadmap, List<int> coursesId)
        {
            try
            {
                var existingCourses = await courseRepo
                        .FindAsync(s => coursesId.Contains(s.Id));

                roadmap.Courses = [.. existingCourses];

                await roadmapRepo.AddAsync(roadmap);

                await roadmapRepo.SaveChangesAsync();

                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse.FailureResult("Error");
            }
        }

        public async Task<ApiResponse<List<Roadmap>>> GetEnrolledRoadmaps(string? studentId)
        {
            try
            {
                var result = await enrollmentRepo
                    .Query()
                    .Where(e => e.StudentId == studentId)
                    .Include(e => e.Roadmap)
                    .ThenInclude(c => c!.Contributor)


                    .Include(x => x.Roadmap)
                    .ThenInclude(x => x!.Courses)
                    .ThenInclude(x => x!.Materials)
                    .ThenInclude(x => x!.Contributor)


                    .Include(x => x.Roadmap)
                    .ThenInclude(x => x!.Specialization)
                    .Select(e => e.Roadmap!).ToListAsync();

                return ApiResponse<List<Roadmap>>.SuccessResult(result);
            }
            catch (Exception)
            {
                return ApiResponse<List<Roadmap>>.FailureResult("Error");
            }
        }

        public async Task<ApiResponse> DropRoadmap(string? studentId, int roadmapId)
        {
            try
            {
                var enrollment = await enrollmentRepo.Query().FirstOrDefaultAsync(e => e.RoadmapId == roadmapId && e.StudentId == studentId);
                if (enrollment != null)
                {
                    enrollmentRepo.Remove(enrollment);
                    await enrollmentRepo.SaveChangesAsync();
                }
                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                return ApiResponse.FailureResult("Error");
            }
        }
        public async Task<ApiResponse> EnrollRoadmap(string? studentId, int roadmapId)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(studentId);

                RoadmapEnrollment enrollment = new() { StudentId = studentId, RoadmapId = roadmapId };

                await enrollmentRepo.AddAsync(enrollment);
                await enrollmentRepo.SaveChangesAsync();

                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                return ApiResponse.FailureResult("Error");
            }
        }

    }
}
