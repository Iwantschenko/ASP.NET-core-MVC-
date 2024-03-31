using System.Text.RegularExpressions;
using App.DAL.Infrastructure;
using App.DAL.DB;
using Microsoft.EntityFrameworkCore;

using App.BLL;
using App.BLL.Mapping;
using App.Models.Entities;
using App.Models.Models;



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
            builder.Services.AddScoped<ServiceRepository<Course , CourseModel>>();
            builder.Services.AddScoped<IMapping<Course, CourseModel>,CourseMapping>();

            builder.Services.AddScoped<IRepository<Models.Entities.Group>, BaseRepository<Models.Entities.Group>>();
            builder.Services.AddScoped<ServiceRepository<Models.Entities.Group, GroupModel>>();
            builder.Services.AddScoped<IMapping<Models.Entities.Group, GroupModel>, GroupMapping>();

            builder.Services.AddScoped<IRepository<Teacher>, BaseRepository<Teacher>>();
            builder.Services.AddScoped<ServiceRepository<Teacher, TeacherModel>>();
            builder.Services.AddScoped<IMapping<Teacher, TeacherModel>, TeacherMapping>();

            builder.Services.AddScoped<IRepository<Student>, BaseRepository<Student>>();
            builder.Services.AddScoped<ServiceRepository<Student, StudentModel>>();
            builder.Services.AddScoped<IMapping<Student, StudentModel>, StudentMapping>();



            builder.Services.AddControllersWithViews();
            var app = builder.Build();




            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");





            app.Run();
        }
    }
}
