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
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(contextDb).Assembly
            );

        }
    }
}