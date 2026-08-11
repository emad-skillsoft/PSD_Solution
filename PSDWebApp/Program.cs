using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PSDWebApp.Data;
using PSDWebApp.Services;
namespace PSDWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();


            //builder.Services.AddSingleton<ICustomerService, CustomerMemoryService>();
            builder.Services.AddScoped<ICustomerService, CustomerDBService>();



            var connectionString = builder.Configuration.GetConnectionString("PSDWebAppContext") ?? throw new InvalidOperationException("Connection string 'PSDWebAppContext' not found.");
            builder.Services.AddDbContext<PSDWebAppContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                            .AddRoles<IdentityRole>()
                            .AddEntityFrameworkStores<PSDWebAppContext>()
                            .AddSignInManager<SignInManager<ApplicationUser>>();






            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // configure the app to serve static files from the wwwroot folder


            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Customer}/{action=Index}/{id?}")
                .WithStaticAssets();
            app.MapRazorPages();


            using (var scope = app.Services.CreateScope())
            {
                var roleManager =
                    scope.ServiceProvider
                        .GetRequiredService<RoleManager<IdentityRole>>();
                var userManager =
                scope.ServiceProvider
                     .GetRequiredService<UserManager<ApplicationUser>>();
                IdentitySeeder.SeedRoles(userManager, roleManager);
            }


            app.Run();
        }
    }
}
