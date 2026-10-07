using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeTaskManagement.Entities.Concrete;

namespace EmployeeTaskManagement.DataAccess.Concrete.EntityFramework.Contexts
{
    public class EmployeeTaskManagementContext : DbContext
    {
        public static string ConnectionString { get; set; } = string.Empty;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(ConnectionString))
                throw new InvalidOperationException("Connection string is not set.");

            optionsBuilder.UseSqlite(ConnectionString);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}