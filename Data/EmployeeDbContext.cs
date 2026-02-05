using EmployeeManagementSystem.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EmployeeManagementSystem.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<LeaveRequest> LeaveRequests => Set<LeaveRequest>();
        public DbSet<Payroll> Payrolls => Set<Payroll>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Employee → Department
            //    modelBuilder.Entity<Employee>()
            //        .HasOne(e => e.Department)
            //        .WithMany(d => d.Employees)
            //        .HasForeignKey(e => e.DepartmentId)
            //        .OnDelete(DeleteBehavior.Restrict);

            //    // Self-reference (Manager)
            //    modelBuilder.Entity<Employee>()
            //        .HasOne(e => e.Manager)
            //        .WithMany(e => e.Subordinates)
            //        .HasForeignKey(e => e.ManagerId)
            //        .OnDelete(DeleteBehavior.Restrict);

            //    // LeaveRequest → Employee
            //    modelBuilder.Entity<LeaveRequest>()
            //        .HasOne(l => l.Employee)
            //        .WithMany(e => e.LeaveRequests)
            //        .HasForeignKey(l => l.EmployeeId);

            //    // Payroll → Employee
            //    modelBuilder.Entity<Payroll>()
            //        .HasOne(p => p.Employee)
            //        .WithMany(e => e.Payrolls)
            //        .HasForeignKey(p => p.EmployeeId);

            //    // ✅ Decimal precision configuration

            //    modelBuilder.Entity<Employee>()
            //        .Property(e => e.BasicSalary)
            //        .HasPrecision(18, 2);

            //    modelBuilder.Entity<Payroll>(entity =>
            //    {
            //        entity.Property(p => p.Basic)
            //            .HasPrecision(18, 2);

            //        entity.Property(p => p.Allowances)
            //            .HasPrecision(18, 2);

            //        entity.Property(p => p.Deductions)
            //            .HasPrecision(18, 2);
            //    });
            //}
            modelBuilder.Entity<Department>().HasData(
    new Department
    {
        Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        Name = "Human Resources",
        Description = "HR department"
    },
    new Department
    {
        Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
        Name = "IT",
        Description = "Technology department"
    },
    new Department
    {
        Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
        Name = "Finance",
        Description = "Finance department"
    },
    new Department
    {
        Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
        Name = "Operations",
        Description = "Operations department"
    }
);

        }
    }
}