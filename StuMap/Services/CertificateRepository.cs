using Microsoft.EntityFrameworkCore;
using StuMap.Context;
using StuMap.Managers;
using StuMap.Models;

namespace StuMap.Services
{
    public class CertificateRepository : ICertificateManager
    {
        AppDbContext context;
        public CertificateRepository(AppDbContext context)
        {
            this.context = context;
        }

        public List<Certificate> GetAll()
        {
         return context.Certificates.Include(c => c.Contributor).ToList();
        }

        public Certificate GetById(int id)
        {
            return context.Certificates.Include(c => c.Contributor).FirstOrDefault(c => c.Id == id);
        }

        public int Insert(Certificate entity)
        {
            context.Certificates.Add(entity);
            return context.SaveChanges();
        }

        public int Update(int id, Certificate entity)
        {
            var existingCertificate = context.Certificates.Find(id);
            if (existingCertificate != null)
            {
                context.Entry(existingCertificate).CurrentValues.SetValues(entity);
                return context.SaveChanges();
            }
            return 0;
        }
        public int Delete(int id)
        {
             var existingCertificate = context.Certificates.Find(id);
             if (existingCertificate != null)
             {
                 context.Certificates.Remove(existingCertificate);
                 return context.SaveChanges();
             }
             return 0;
        }

      
    }
}
