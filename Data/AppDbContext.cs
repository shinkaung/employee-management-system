using EMS.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}