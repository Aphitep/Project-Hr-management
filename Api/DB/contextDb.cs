using Api.Configurations;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.DB
{
    public class contextDb : DbContext
    {
        public contextDb(DbContextOptions<contextDb> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfiguration).Assembly);
        }
    }
}