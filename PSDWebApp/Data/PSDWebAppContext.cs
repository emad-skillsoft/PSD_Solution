using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PSDWebApp.Models;

namespace PSDWebApp.Data
{

    public class PSDWebAppContext(DbContextOptions<PSDWebAppContext> options)
        : IdentityDbContext<ApplicationUser, IdentityRole, string>(options) //DbContext(options)
    {
        public DbSet<Customer> Customer { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}