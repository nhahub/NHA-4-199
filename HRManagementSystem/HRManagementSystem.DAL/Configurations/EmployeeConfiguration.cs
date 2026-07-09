using HRManagementSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> e)
        {
            e.ToTable("EmployeesInfo", "dbo")
               .HasKey(d => d.Id);

            e.Property(d => d.Id)
                .UseIdentityColumn(10, 10)
                .HasColumnName("EmployeeID");

            e.Property(e => e.HireDate)
                .HasColumnName("EmployeeHirDate")
                .HasColumnType("Date")
                .IsRequired();

            e.Property(e => e.EFF_Start)
                .HasColumnName("EmployeeEFF_Start")
                .HasColumnType("Date")
                .IsRequired();

            e.Property(e => e.EFF_End)
                .HasColumnName("EmployeeEFF_End")
                .HasColumnType("Date")
                .IsRequired();

            e.Property(e => e.BasicSalary)
                .HasColumnName("EmployeeBaseSalary")
                .HasColumnType("Decimal(18,2)")
                .IsRequired();

            e.Property(e => e.ApplicationUserId)
                .HasColumnName("employeeAplication")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            e.Property(e => e.PersonId)
            .HasColumnName("PersonID")
            .IsRequired();

            e.Property(e => e.DepartmentId)
                .HasColumnName("EmployeeDepartment")
                .HasColumnType("int")
                .IsRequired();

            e.Property(e => e.ManagerId)
                .HasColumnName("EmployeeManger")
                .HasColumnType("int");


            //Rlation With Department

            e.HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

            //Self Relation Mange

            e.HasOne(e => e.Manager)
            .WithMany(e => e.EmployeesManaged)
            .HasForeignKey(e => e.ManagerId)
            .OnDelete(DeleteBehavior.NoAction);


            e.HasOne(e => e.Person)
            .WithOne(p => p.Employee)
            .HasForeignKey<Employee>(e => e.PersonId)
            .OnDelete(DeleteBehavior.NoAction);




        }
    }
}
