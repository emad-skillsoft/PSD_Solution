using Microsoft.EntityFrameworkCore;
using PreProjectDemo.Data;
namespace PreProjectDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("PreProjectDemoContext") ?? 
                throw new InvalidOperationException("Connection string 'PreProjectDemoContext' not found.");

            builder.Services.AddDbContext<PreProjectDemoContext>(options => options.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Customer}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
