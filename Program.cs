using FoodMart.Models.Infrastucture;
using Microsoft.EntityFrameworkCore;

namespace FoodMart
{
    public class Program
    {
        public static User CurrentUser { get; set; }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var db = builder.Configuration.GetConnectionString("Db");

            builder.Services.AddDbContext<MainContext>(options => options.UseSqlServer(db));

            var app = builder.Build();

            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Registration}");

            app.UseStaticFiles();

            app.Run();
        }
    }
}