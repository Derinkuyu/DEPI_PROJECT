using Microsoft.EntityFrameworkCore;
using StuMap.BLL.Models;
using StuMap.BLL.Services;
using StuMap.DAL.Models;
using StuMap.DAL.Models.Enums;
using StuMap.DAL.Repositories.Interfaces;
using System.Net;

namespace StuMap.BLL.Managers
{
    public class CourseService(
        IGenericRepository<Course> courseRepo,
        IGenericRepository<CourseEnrollment> enrollmentRepo) : ICourseService
    {
        public async Task<ApiResponse<List<Course>>> GetApprovedCourses()
        {
            try
            {
                var result = await courseRepo
                    .Query()
                    .Where(x => x.Status == StatusEnum.Approved)
                    .Include(x => x.Contributor)
                    .Include(c => c.Materials)
                    .ThenInclude(m => m.MaterialType).ToListAsync();


                return ApiResponse<List<Course>>.SuccessResult([.. result]);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<List<Course>>.FailureResult("Error");
            }
        }

        public async Task<ApiResponse<Course>> GetCourse(int id)
        {
            try
            {
                var result = await courseRepo
                    .Query()
                    .Include(c => c.Contributor)
                    .Include(c => c.Materials)
                    .ThenInclude(m => m.MaterialType)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (result == null)
                    return ApiResponse<Course>.FailureResult("Not found", HttpStatusCode.NotFound);


                return ApiResponse<Course>.SuccessResult(result);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<Course>.FailureResult("Error");
            }
        }

        public async Task<ApiResponse<List<Course>>> GetEnrolledCourses(string? studentId)
        {
            try
            {
                var result = await enrollmentRepo
                    .Query()
                    .Where(e => e.StudentId == studentId)
                    .Include(e => e.Course)
                    .ThenInclude(c => c!.Contributor)
                    .Select(e => e.Course!).ToListAsync();

                return ApiResponse<List<Course>>.SuccessResult(result);
            }
            catch (Exception)
            {
                return ApiResponse<List<Course>>.FailureResult("Error");
            }
        }

        public async Task<ApiResponse> DropCourse(string? studentId, int courseId)
        {
            try
            {
                var enrollment = await enrollmentRepo.Query().FirstOrDefaultAsync(e => e.CourseId == courseId && e.StudentId == studentId);
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
        public async Task<ApiResponse> EnrollCourse(string? studentId, int courseId)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(studentId);

                CourseEnrollment enrollment = new() { StudentId = studentId, CourseId = courseId };

                await enrollmentRepo.AddAsync(enrollment);
                await enrollmentRepo.SaveChangesAsync();

                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                return ApiResponse.FailureResult("Error");
            }
        }

        public async Task<ApiResponse<List<Course>>> GetMyCourses(string? contributorId)
        {
            try
            {
                var result = await courseRepo
                    .Query()
                    .Include(c => c.Contributor)
                    .Include(c => c.Materials)
                    .ThenInclude(m => m.MaterialType)
                    .Where(x => x.ContributorId == contributorId).ToListAsync();


                return ApiResponse<List<Course>>.SuccessResult(result);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<List<Course>>.FailureResult("Error");
            }
        }

        public async Task<ApiResponse<bool>> IsEnrolledInCourse(string? userId, int courseId)
        {
            try
            {
                var result = await enrollmentRepo
                    .Query()
                    .AnyAsync(e => e.StudentId == userId && e.CourseId == courseId);

                return ApiResponse<bool>.SuccessResult(result);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<bool>.FailureResult("Error");
            }
        }

        public async Task<ApiResponse> SaveCourseAndMaterials(Course course, List<Material> materials)
        {
            try
            {
                course.Materials.Clear();
                foreach (var item in materials)
                {
                    course.Materials.Add(item);
                }

                await courseRepo.AddAsync(course);

                await courseRepo.SaveChangesAsync();

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
