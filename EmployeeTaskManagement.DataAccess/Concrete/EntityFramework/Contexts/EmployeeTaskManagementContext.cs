using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeTaskManagement.Core.Entities.Concrete;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.ToTable("TaskItems");
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Title).IsRequired().HasMaxLength(200);
                entity.Property(t => t.Description).HasMaxLength(1000);

                entity.HasOne(t => t.Employee)
                    .WithMany(e => e.Tasks)
                    .HasForeignKey(t => t.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(t => t.EmployeeId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Username).IsRequired().HasMaxLength(50);
                entity.Property(u => u.PasswordHash).IsRequired();

                entity.HasIndex(u => u.Username).IsUnique();
            });
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<User> Users { get; set; }
    }
}