using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Data
{
    public class EmployeeAuthDbContext: IdentityDbContext
    {
        public EmployeeAuthDbContext(DbContextOptions<EmployeeAuthDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var adminId = "9955684e-9bad-44de-857e-0298c16599a3";
            var userId = "35834d40-ad60-4442-a9ae-aa16838c229c";
            var roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id=adminId,
                    ConcurrencyStamp=adminId,
                    Name="Admin",
                    NormalizedName="ADMIN"
                },
                new IdentityRole()
                {
                    Id=userId,
                    ConcurrencyStamp=userId,
                    Name="User",
                    NormalizedName="USER"
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

        }
    }
}
