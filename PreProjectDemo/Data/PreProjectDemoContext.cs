using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PreProjectDemo.Models;

namespace PreProjectDemo.Data
{
    public class PreProjectDemoContext(DbContextOptions<PreProjectDemoContext> options) :
         IdentityDbContext<ApplicationUser, IdentityRole, string>(options)
        //DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }



    }
}
