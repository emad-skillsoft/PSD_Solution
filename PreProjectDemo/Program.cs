using Microsoft.EntityFrameworkCore;
using PreProjectDemo.Data;
using PreProjectDemo.Services;
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
            builder.Services.AddScoped<ICustomerService, CustomerMSSQLService>();


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
                pattern: "{controller=Customers}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
