using Final_Project_PVI.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_PVI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<AccesoDatos>();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5);  
                options.Cookie.HttpOnly = true;  
                options.Cookie.IsEssential = true; 
            });

            builder.Services.AddSingleton<AccesoDatos>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Start}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
