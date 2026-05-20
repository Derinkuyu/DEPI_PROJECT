using Microsoft.EntityFrameworkCore;
using StuMap.Context;
using StuMap.DTO.Admin;
using StuMap.Managers;
using StuMap.Models;
using StuMap.Models.Enums;

namespace StuMap.Services
{
    public class CourseRepository : ICourseManager
    {
        AppDbContext context;
        public CourseRepository(AppDbContext context)
        {
            this.context = context;
        }
        public List<Course> GetAll()
        {
            return context.Courses
                .Include(c => c.Contributor)
                .Include(c => c.Materials)
                .ThenInclude(m => m.MaterialType)
                .ToList();
        }

        public Course GetById(int id)
        {
            return context.Courses
                .Include(c => c.Contributor)
                .Include(c => c.Materials)
                .ThenInclude(m => m.MaterialType)
                .FirstOrDefault(c => c.Id == id);
        }

        public int Insert(Course entity)
        {
           context.Courses.Add(entity);
           context.SaveChanges();
           return entity.Id;
        }

        public int Update(int id, Course entity)
        {
            var oldCourse = GetById(id);
            if (oldCourse != null)
            {
                oldCourse.Title = entity.Title;
                oldCourse.Description = entity.Description;
                oldCourse.ContributorId = entity.ContributorId;
                oldCourse.Status = entity.Status;
                oldCourse.DateCreated = entity.DateCreated;
                oldCourse.Materials = entity.Materials;
                context.Courses.Update(oldCourse);
                return context.SaveChanges();
            }
            return 0;
        }
        public int Delete(int id)
        {
            var oldCourse = GetById(id);
            if (oldCourse != null)
            {
                context.Courses.Remove(oldCourse);
                return context.SaveChanges();
            }
            return 0;
        }
        /*--------------------------------------------------------------------------------*/
        /////For Course Mangement
        /*--------------------------------------------------------------------------------*/
        public List<CourseRequestDto> GetPendingCourses()
        {
            return context.Courses
                .Where(c =>
                    c.Status == CourseStatus.Pending ||
                    c.Status == CourseStatus.UpdatedPending)
                .Select(c => new CourseRequestDto
                {
                    Id = c.Id,

                    Title = c.Title,

                    ContributorName =
                        c.Contributor != null
                            ? $"{c.Contributor.FirstName} {c.Contributor.LastName}"
                            : "Unknown Contributor",

                    RoadmapName = c.CourseRoadmaps!
                        .Select(r => r.Roadmap.Title)
                        .FirstOrDefault(),

                    MaterialsCount = c.Materials.Count(),

                    Status = c.Status,

                    SubmittedAt = c.SubmittedAt
                })
                .ToList();
        }
        /*--------------------------------------------------------------------------------*/
        public List<CourseRequestDto> GetAllCourses()
        {
            return context.Courses
                .Where(c => !c.IsDeleted)
                .Select(c => new CourseRequestDto
                {
                    Id = c.Id,

                    Title = c.Title,

                    ContributorName =
                        c.Contributor != null
                            ? $"{c.Contributor.FirstName} {c.Contributor.LastName}"
                            : "Unknown Contributor",

                    RoadmapName = c.CourseRoadmaps!
                        .Select(r => r.Roadmap.Title)
                        .FirstOrDefault(),

                    MaterialsCount = c.Materials.Count(),

                    Status = c.Status,

                    SubmittedAt = c.SubmittedAt
                })
                .ToList();
        }
        /*--------------------------------------------------------------------------------*/
        public CourseDetailsDto GetCourseById(int id)
        {
            var course = context.Courses
                .Include(c => c.Contributor)
                .Include(c => c.Materials)
                .Include(c => c.CourseRoadmaps!)
                    .ThenInclude(cr => cr.Roadmap)
                .FirstOrDefault(c => c.Id == id);

            if (course == null)
                return null;

            return new CourseDetailsDto
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                ContributorName = $"{course.Contributor.FirstName} {course.Contributor.LastName}" ?? "Unknown Contributor",
                ContributorEmail = course.Contributor?.Email ?? "No Email",
                RoadmapName = course.CourseRoadmaps?.Select(r => r.Roadmap.Title).FirstOrDefault(),
                Status = course.Status,
                RejectionReason = course.RejectionReason,
                DateCreated = course.DateCreated,
                SubmittedAt = course.SubmittedAt,
                ApprovedAt = course.ApprovedAt,
                MaterialsCount = course.Materials.Count(),
                Materials = course.Materials
                    .Select(m => new MaterialDto
                    {
                        Id = m.Id,
                        Title = m.Title,
                        Description = m.Description,
                        Url = m.Url,
                        MaterialType = m.MaterialType?.Title ?? string.Empty
                    })
                    .ToList()
            };
        }
        /*--------------------------------------------------------------------------------*/
        public void ApproveCourse(int id)
        {
            var course = context.Courses
                .FirstOrDefault(c => c.Id == id);

            if (course != null)
            {
                course.Status = CourseStatus.Approved;

                course.ApprovedAt = DateTime.Now;

                course.RejectionReason = null;

                context.SaveChanges();
            }
        }
        /*--------------------------------------------------------------------------------*/
        public void RejectCourse(int id, string reason)
        {
            var course = context.Courses
                .FirstOrDefault(c => c.Id == id);

            if (course != null)
            {
                course.Status = CourseStatus.Rejected;

                course.RejectionReason = reason;

                context.SaveChanges();
            }
        }
        /*--------------------------------------------------------------------------------*/
        public void DeleteCourse(int id)
        {
            var course = context.Courses
                .FirstOrDefault(c => c.Id == id);

            if (course != null)
            {
                course.IsDeleted = true;

                context.SaveChanges();
            }
        }

        /*--------------------------------------------------------------------------------*/

    }
}
