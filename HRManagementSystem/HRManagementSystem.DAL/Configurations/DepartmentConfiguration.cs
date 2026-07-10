using HRManagementSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Department> d)
        {
           d.ToTable("DepartmentInfo", "dbo")
                .HasKey(d => d.Id);

            d.Property(d => d.Id)
                .UseIdentityColumn(10, 10)
                .HasColumnName("DepartmentID");

            d.Property(d => d.Name)
                .HasColumnName("DepartmentName")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            d.Property(d => d.Description)
                .HasColumnName("DepartmentDescription")
                .HasColumnType("varchar")
                .HasMaxLength(500);
                

            d.Property(d => d.ManagerId)
                .HasColumnName("DepartmentMangr")
                .HasColumnType("int")
                .IsRequired();

            d.Property(d => d.EmployeeCount)
                .HasColumnName("CountOfDepartmentEmployee")
                .HasColumnType("int")
                .IsRequired();

            //Relationships

            d.HasOne(d => d.Manager)
            .WithOne()
            .HasForeignKey<Department>(d => d.ManagerId)
            .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
