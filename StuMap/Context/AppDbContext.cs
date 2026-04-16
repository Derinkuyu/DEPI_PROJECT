using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using StuMap.Models;
namespace StuMap.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Roadmap> Roadmaps { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=StuMapDb;Integrated Security =True;Encrypt =False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().UseTptMappingStrategy();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Contacts)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Contributor>()
                .HasMany(e => e.Certificates)
                .WithOne(e => e.Contributor)
                .HasForeignKey(e => e.ContributorId);

            modelBuilder.Entity<Roadmap>()
                .HasOne(e => e.Specialization)
                .WithMany(e => e.Roadmaps)
                .HasForeignKey(e => e.SpecializationId);

            modelBuilder.Entity<Roadmap>()
                .HasMany(e => e.Courses)
                .WithOne(e => e.Roadmap)
                .HasForeignKey(e => e.RoadmapId);

            modelBuilder.Entity<Roadmap>()
                .HasOne(e => e.Contributor)
                .WithMany()
                .HasForeignKey(e => e.ContributorId);

            modelBuilder.Entity<Course>()
                .HasOne(e => e.Contributor)
                .WithMany()
                .HasForeignKey(e => e.ContributorId);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Materials)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Material>()
                .HasOne(e => e.Contributor)
                .WithMany()
                .HasForeignKey(e => e.ContributorId);


            modelBuilder.Entity<Student>()
                .HasMany(e => e.Roadmaps)
                .WithMany(e => e.Students)
                .UsingEntity<Enrollment>(
                    r => r.HasOne(e => e.Roadmap).WithMany(e => e.Enrollments).HasForeignKey(e => e.RoadmapId),
                    l => l.HasOne(e => e.Student).WithMany(e => e.Enrollments).HasForeignKey(e => e.StudentId));
        }
    }
}
