using Microsoft.EntityFrameworkCore;
using StuMap.Context;
using StuMap.Managers;
using StuMap.Models;

namespace StuMap.Services
{
    public class EnrollmentRepository : IEnrollmentManager
    {
        AppDbContext context;
        public EnrollmentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public List<Enrollment> GetAll()
        {
            return context.Enrollments.Include(e => e.Student).Include(e => e.Roadmap).ToList();
        }

        public Enrollment GetById(int id)
        {
            return context.Enrollments.Include(e => e.Student).FirstOrDefault(e => e.RoadmapId == id);
        }

        public int Insert(Enrollment entity)
        {
            context.Enrollments.Add(entity);
            return context.SaveChanges();
        }
        //the enrollment mustn't be updated
        public int Update(int id, Enrollment entity)
        {
            throw new NotImplementedException();
        }
        //the enrollment mustn't be deleted by only one id 
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
