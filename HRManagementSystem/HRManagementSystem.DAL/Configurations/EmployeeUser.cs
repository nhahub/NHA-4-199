using HRManagementSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.DAL.Configurations
{
    public class EmployeeUser : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
    .HasOne(u => u.Employee)
    .WithOne(e => e.User)
    .HasForeignKey<ApplicationUser>(u => u.EmployeeId)
    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
