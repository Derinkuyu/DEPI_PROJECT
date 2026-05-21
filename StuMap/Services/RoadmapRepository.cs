using Microsoft.EntityFrameworkCore;
using StuMap.Context;
using StuMap.DTO.Admin;
using StuMap.Managers;
using StuMap.Models;
using StuMap.Models.Enums;

namespace StuMap.Services
{
    public class RoadmapRepository(AppDbContext context, ICourseManager courseRepository) : IRoadmapManager
    {

        /*------------------------------------------------------------------------------*/
        public List<Roadmap> GetAll()
        {
            return context.Roadmaps
                .Include(r => r.Specialization)
                .Include(r => r.Contributor)
                .Include(r => r.CourseRoadmaps)
                .ThenInclude(cr => cr.Course)
                .ThenInclude(c => c.Materials)
                .ThenInclude(c => c.Contributor)
                .ToList();
        }

        /*------------------------------------------------------------------------------*/
        public Roadmap GetById(int id)
        {
            return context.Roadmaps
                .Include(r => r.Specialization)
                .Include(r => r.Contributor)
                .Include(r => r.CourseRoadmaps)
                .ThenInclude(cr => cr.Course)
                .ThenInclude(c => c.Materials)
                .ThenInclude(c => c.Contributor)
                .FirstOrDefault(r => r.Id == id);
        }

        /*------------------------------------------------------------------------------*/
        public int Insert(Roadmap entity)
        {
            context.Roadmaps.Add(entity);
            context.SaveChanges();
            return entity.Id;
        }


        /*------------------------------------------------------------------------------*/
        public int Update(int id, Roadmap entity)
        {
            var existingRoadmap = context.Roadmaps.Find(id);
            if (existingRoadmap != null)
            {
                existingRoadmap.Title = entity.Title;
                existingRoadmap.Description = entity.Description;
                existingRoadmap.ContributorId = entity.ContributorId;
                existingRoadmap.SpecializationId = entity.SpecializationId;

                return context.SaveChanges();
            }
            return 0;
        }
        /*------------------------------------------------------------------------------*/
        public int Delete(int id)
        {
            var existingRoadmap = context.Roadmaps.Find(id);
            if (existingRoadmap != null)
            {
                context.Roadmaps.Remove(existingRoadmap);
                return context.SaveChanges();
            }
            return 0;

        }

        /*------------------------------------------------------------------------------*/
        public List<RoadmapRequestDto> GetPendingRoadmaps()
        {
            return context.Roadmaps
                .Where(r =>
                    r.Status == RoadmapStatus.Pending ||
                    r.Status == RoadmapStatus.UpdatedPending)
                .Select(r => new RoadmapRequestDto
                {
                    Id = r.Id,
                    Name = r.Title,
                    Specialization = r.Specialization.Name,
                    ContributorName = $"{r.Contributor.FirstName} {r.Contributor.LastName}",
                    Status = r.Status,
                    SubmittedAt = r.SubmittedAt,
                    CoursesCount = r.CourseRoadmaps.Count()
                })
                .ToList();
        }
        /*------------------------------------------------------------------------------*/
        public List<RoadmapRequestDto> GetAllRoadmaps()
        {
            return context.Roadmaps
                .Where(r => !r.IsDeleted)
                .Select(r => new RoadmapRequestDto
                {
                    Id = r.Id,
                    Name = r.Title,
                    Specialization = r.Specialization.Name,
                    ContributorName = $"{r.Contributor.FirstName} {r.Contributor.LastName}",
                    Status = r.Status,
                    SubmittedAt = r.SubmittedAt,
                    CoursesCount = r.CourseRoadmaps.Count()
                })
                .ToList();
        }
        /*------------------------------------------------------------------------------*/
        public RoadmapDetailsDto GetRoadmapById(int id)
        {
            var roadmap = context.Roadmaps
                .Include(r => r.Specialization)
                .Include(r => r.Contributor)
                .Include(r => r.CourseRoadmaps)
                .ThenInclude(cr => cr.Course)
                .ThenInclude(c => c.Materials)
                .ThenInclude(c => c.Contributor)
                .FirstOrDefault(r => r.Id == id);

            if (roadmap == null)
                return null;

            return new RoadmapDetailsDto
            {
                Id = roadmap.Id,
                Name = roadmap.Title,
                Description = roadmap.Description,
                Specialization = roadmap.Specialization.Name,
                ContributorName = $"{roadmap.Contributor.FirstName} {roadmap.Contributor.LastName}",
                ContributorEmail = roadmap.Contributor.Email,
                Status = roadmap.Status,
                RejectionReason = roadmap.RejectionReason,
                SubmittedAt = roadmap.SubmittedAt,
                ApprovedAt = roadmap.ApprovedAt,

                Courses = roadmap.CourseRoadmaps
                    .Select(c => new Course
                    {
                        Id = c.Course.Id,
                        Title = c.Course.Title
                    }).ToList()
            };
        }
        /*------------------------------------------------------------------------------*/
        public void ApproveRoadmap(int id)
        {
            var roadmap = context.Roadmaps.Include(x => x.CourseRoadmaps)
                .FirstOrDefault(r => r.Id == id);

            if (roadmap != null)
            {
                roadmap.Status = RoadmapStatus.Approved;

                roadmap.ApprovedAt = DateTime.Now;

                roadmap.RejectionReason = null;
                if (roadmap.CourseRoadmaps != null)
                {
                    foreach (var item in roadmap.CourseRoadmaps)
                    {
                        var course = courseRepository.GetById(item.CourseId);
                        course?.Status = CourseStatus.Approved;
                        course?.ApprovedAt = DateTime.UtcNow;
                    }

                }

                context.SaveChanges();
            }
        }
        /*------------------------------------------------------------------------------*/
        public void RejectRoadmap(int id, string reason)
        {
            var roadmap = context.Roadmaps
                .FirstOrDefault(r => r.Id == id);

            if (roadmap != null)
            {
                roadmap.Status = RoadmapStatus.Rejected;

                roadmap.RejectionReason = reason;

                context.SaveChanges();
            }
        }
        /*------------------------------------------------------------------------------*/
        public void DeleteRoadmap(int id)
        {
            var roadmap = context.Roadmaps
                .FirstOrDefault(r => r.Id == id);

            if (roadmap != null)
            {
                roadmap.IsDeleted = true;

                context.SaveChanges();
            }
        }
        /*------------------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------*/


    }
}
