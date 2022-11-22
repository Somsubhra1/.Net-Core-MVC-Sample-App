using System;
using Microsoft.EntityFrameworkCore;

namespace MVCPractice.Models
{
    public class DbConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Designation> Designations { get; set; }

        public DbConnectionContext(DbContextOptions<DbConnectionContext> options) : base(options)
        {
        }

    }
}

