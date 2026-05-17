using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StuMap.API;
using StuMap.Context;
using StuMap.Models;
using StuMap.Services.Authentication;

namespace StuMap
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configure Db connection (Injection)
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StuMapDbConnection")));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
            })
             .AddEntityFrameworkStores<AppDbContext>()
             .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>()
             .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/login";
            });
            AddServices(builder);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }

        static void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();


            // Models and Repositories Injection
            //builder.Services.AddScoped<Managers.IAdminManager, Services.AdminRepository>();
            builder.Services.AddScoped<Managers.IContactManager, Services.ContactRepository>();
            builder.Services.AddScoped<Managers.ICourseManager, Services.CourseRepository>();
            builder.Services.AddScoped<Managers.IEnrollmentManager, Services.EnrollmentRepository>();
            builder.Services.AddScoped<Managers.IRoadmapManager, Services.RoadmapRepository>();
            builder.Services.AddScoped<Managers.ISpecializationManager, Services.SpecializationRepository>();
            //builder.Services.AddScoped<Managers.IStudentManager, Services.StudentRepository>();
            //builder.Services.AddScoped<Managers.IContributorManager, Services.ContributorRepository>();
            builder.Services.AddScoped<Managers.IMaterialManager, Services.MaterialRepository>();
            builder.Services.AddScoped<Managers.ICertificateManager, Services.CertificateRepository>();
            builder.Services.AddScoped<Managers.IMaterialTypeManager, Services.MaterialTypeRepository>();
        }
    }
}
