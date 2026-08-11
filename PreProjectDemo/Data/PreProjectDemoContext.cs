using Microsoft.EntityFrameworkCore;
using PreProjectDemo.Models;

namespace PreProjectDemo.Data
{
    public class PreProjectDemoContext(DbContextOptions<PreProjectDemoContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; } = default!;
    }
}
