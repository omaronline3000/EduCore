using Microsoft.AspNetCore.Identity;
using EduCore.Repository;

namespace EduCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession();

            // Register built-in service
            builder.Services.AddDbContext<APPDbContext>((optionsbuilder) =>
            {
                optionsbuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<APPDbContext>();
 

            // Register custom service
            builder.Services.AddScoped<IDepartmentRepository , DepartmentRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
            builder.Services.AddScoped<CourseService>();
            builder.Services.AddScoped<DepartmentService>();
            builder.Services.AddScoped<InstructorService>();
            builder.Services.AddScoped<TraineeService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseSession(); // TODO: Create Controller and test the session and cookie

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapStaticAssets();

            //app.MapControllerRoute("CoursesByDept", "/CourseByDept/{id:int}", 
            //    new { controller = "Course", action = "GetCoursesByDept" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
