using Microsoft.EntityFrameworkCore;
using MySite.Infrastructure;
using MySite.Models;
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
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            
           
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            




            app.Run();
        }
    }
}
