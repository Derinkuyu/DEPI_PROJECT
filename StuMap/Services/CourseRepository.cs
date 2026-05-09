using Microsoft.EntityFrameworkCore;
using StuMap.Context;
using StuMap.Managers;
using StuMap.Models;

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
                .Include(c => c.Roadmap)
                .Include(c => c.Materials)
                .ToList();
        }

        public Course GetById(int id)
        {
            return context.Courses
                .Include(c => c.Contributor)
                .Include(c => c.Roadmap)
                .Include(c => c.Materials)
                .FirstOrDefault(c => c.Id == id);
        }

        public int Insert(Course entity)
        {
           context.Courses.Add(entity);
           return context.SaveChanges();
        }

        public int Update(int id, Course entity)
        {
            var oldCourse = GetById(id);
            if (oldCourse != null)
            {
                oldCourse.Title = entity.Title;
                oldCourse.Description = entity.Description;
                oldCourse.ContributorId = entity.ContributorId;
                oldCourse.RoadmapId = entity.RoadmapId;
                oldCourse.IsApproved = entity.IsApproved;
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
    }
}
