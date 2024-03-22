using System.Text.RegularExpressions;
using App.DAL.Infrastructure;
using App.DAL.Models;
using App.DAL.DB;
using App.BLL;
using Microsoft.EntityFrameworkCore;

namespace App.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DataBaseContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppSettingConnectionString"))
                );

            builder.Services.AddScoped<IRepository<Course>, BaseRepository<Course>>();
            builder.Services.AddScoped<ServiceRepository<Course>>();

            builder.Services.AddScoped<IRepository<DAL.Models.Group>, BaseRepository<DAL.Models.Group>>();
            builder.Services.AddScoped<ServiceRepository<DAL.Models.Group>>();

            builder.Services.AddScoped<IRepository<Teacher>, BaseRepository<Teacher>>();
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
