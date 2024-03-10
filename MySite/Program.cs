using Microsoft.EntityFrameworkCore;
using MySite.Infrastructure;
using MySite.Models;
using System.Resources;

namespace MySite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DataBaseContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppSettingConnectionString"))
                );

            builder.Services.AddScoped<IRepository<Course>,BaseRepository<Course>>();
            builder.Services.AddScoped<ServiceRepository<Course>>();

            builder.Services.AddScoped<IRepository<Group>,BaseRepository<Group>>();
            builder.Services.AddScoped<ServiceRepository<Group>>();

            builder.Services.AddScoped<IRepository<Teacher>,BaseRepository<Teacher>>();
            builder.Services.AddScoped<ServiceRepository<Teacher>>();

            builder.Services.AddScoped<IRepository<Student>, BaseRepository<Student>>();
            builder.Services.AddScoped<ServiceRepository<Student>>();


            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            
           
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            




            app.Run();
        }
    }
}
