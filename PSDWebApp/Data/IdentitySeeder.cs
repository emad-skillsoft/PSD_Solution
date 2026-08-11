using Microsoft.AspNetCore.Identity;

namespace PSDWebApp.Data
{
    public class IdentitySeeder
    {
        public static void SeedRoles(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin")
                .GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(
                    new IdentityRole("Admin"))
                    .GetAwaiter().GetResult();
            }

            if (!roleManager.RoleExistsAsync("User")
                .GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(
                    new IdentityRole("User"))
                    .GetAwaiter().GetResult();
            }

            // Check whether admin user already exists
            var admin = userManager
                .FindByNameAsync("admin")
                .GetAwaiter()
                .GetResult();

            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = "admin"
                };

                var result = userManager
                    .CreateAsync(admin, "Admin123!")
                    .GetAwaiter()
                    .GetResult();

                if (!result.Succeeded)
                {
                    throw new Exception(
                        string.Join("; ",
                            result.Errors.Select(e => e.Description)));
                }
            }

            // Make sure admin has Admin role
            if (!userManager
                .IsInRoleAsync(admin, "Admin")
                .GetAwaiter()
                .GetResult())
            {
                userManager
                    .AddToRoleAsync(admin, "Admin")
                    .GetAwaiter()
                    .GetResult();
            }
        }
    }

}
