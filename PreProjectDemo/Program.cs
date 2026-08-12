using Microsoft.EntityFrameworkCore;
using PreProjectDemo.Data;
using PreProjectDemo.Services;
using Microsoft.AspNetCore.Identity;
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

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                            .AddRoles<IdentityRole>()
                            .AddEntityFrameworkStores<PreProjectDemoContext>()
                            .AddSignInManager<SignInManager<ApplicationUser>>();



            builder.Services.AddScoped<ICustomerService, CustomerMSSQLService>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Customers}/{action=Index}/{id?}")
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
