using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StuMap.DAL.DataSeeding;
using StuMap.DAL.Models;
namespace StuMap.DAL.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
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
        public virtual DbSet<MaterialType> MaterialTypes { get; set; }
        public virtual DbSet<RoadmapEnrollment> RoadmapEnrollment { get; set; }
        public virtual DbSet<CourseEnrollment> CourseEnrollments { get; set; }
        public virtual DbSet<StudentRoadmapProgress> RoadmapsProgresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MaterialTypeSeedConfiguration());

            modelBuilder.ApplyConfiguration(new IdentityRoleSeedConfiguration());

            modelBuilder.ApplyConfiguration(new IdentityUserSeedConfiguration());

            modelBuilder.ApplyConfiguration(new SpecializationSeedConfiguration());

            modelBuilder.ApplyConfiguration(new IdentityUserRoleSeedConfiguration());

            modelBuilder.ApplyConfiguration(new CourseSeedConfiguration());

            modelBuilder.ApplyConfiguration(new MaterialSeedConfiguration());

            modelBuilder.ApplyConfiguration(new RoadmapSeedConfiguration());
            modelBuilder.ApplyConfiguration(new CourseEnrollmentSeedConfiguration());
            modelBuilder.ApplyConfiguration(new TicketSeedConfiguration());
            modelBuilder.ApplyConfiguration(new CertificateSeedConfiguration());
            modelBuilder.ApplyConfiguration(new CourseRoadmapSeedConfiguration());

            modelBuilder.ApplyConfiguration(new RoadmapEnrollmentSeedConfiguration());

            //    //modelBuilder.Entity<User>().UseTptMappingStrategy();

            // todo: configure all relationships

            modelBuilder.Entity<ApplicationUser>()
                .HasMany<Certificate>()
                .WithOne(e => e.Contributor)
                .HasForeignKey(e => e.ContributorId);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany<Contact>()
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId).IsRequired(true);

            modelBuilder.Entity<CourseRoadmap>()
            .HasKey(cr => new { cr.CoursesId, cr.RoadmapId });

            modelBuilder.Entity<Roadmap>()
                .HasOne(e => e.Specialization)
                .WithMany(e => e.Roadmaps)
                .HasForeignKey(e => e.SpecializationId);

            modelBuilder.Entity<Roadmap>()
                .HasMany(e => e.Courses)
                .WithMany().UsingEntity<CourseRoadmap>();

            modelBuilder.Entity<Roadmap>()
                .HasOne(e => e.Contributor)
                .WithMany()
                .HasForeignKey(e => e.ContributorId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Course>()
                .HasOne(e => e.Contributor)
                .WithMany()
                .HasForeignKey(e => e.ContributorId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Materials)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId).IsRequired(true);

            modelBuilder.Entity<Material>()
                .HasOne(e => e.Contributor)
                .WithMany()
                .HasForeignKey(e => e.ContributorId);

            modelBuilder.Entity<RoadmapEnrollment>()
                .HasKey(e => new { e.RoadmapId, e.StudentId });

            modelBuilder.Entity<CourseEnrollment>()
              .HasKey(e => new { e.CourseId, e.StudentId });

            modelBuilder.Entity<StudentRoadmapProgress>()
              .HasKey(e => new { e.RoadmapId, e.StudentId, e.CourseId });




            //modelBuilder.Entity<Student>()
            //    .HasMany(e => e.Roadmaps)
            //    .WithMany(e => e.Students)
            //    .UsingEntity<Enrollment>(
            //        r => r.HasOne(e => e.Roadmap).WithMany(e => e.Enrollments).HasForeignKey(e => e.RoadmapId),
            //        l => l.HasOne(e => e.Student).WithMany(e => e.Enrollments).HasForeignKey(e => e.StudentId));

        }
    }
}
