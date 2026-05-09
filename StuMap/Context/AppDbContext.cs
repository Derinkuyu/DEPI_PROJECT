using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StuMap.Models;
namespace StuMap.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //public virtual DbSet<Student> Students { get; set; }
        //public virtual DbSet<Admin> Admins { get; set; }
        //public virtual DbSet<Contributor> Contributors { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }
        public virtual DbSet<Roadmap> Roadmaps { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //    //modelBuilder.Entity<User>().UseTptMappingStrategy();

            //    //modelBuilder.Entity<User>()
            //    //    .HasMany(e => e.Contacts)
            //    //    .WithOne(e => e.User)
            //    //    .HasForeignKey(e => e.UserId);

            //    modelBuilder.Entity<Contributor>()
            //        .HasMany(e => e.Certificates)
            //        .WithOne(e => e.Contributor)
            //        .HasForeignKey(e => e.ContributorId);

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
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.RoadmapId, e.StudentId });

            //modelBuilder.Entity<Student>()
            //    .HasMany(e => e.Roadmaps)
            //    .WithMany(e => e.Students)
            //    .UsingEntity<Enrollment>(
            //        r => r.HasOne(e => e.Roadmap).WithMany(e => e.Enrollments).HasForeignKey(e => e.RoadmapId),
            //        l => l.HasOne(e => e.Student).WithMany(e => e.Enrollments).HasForeignKey(e => e.StudentId));

        }
    }
}
