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
    internal class Payrollconfiguration : IEntityTypeConfiguration<Payroll>
    {
        public void Configure(EntityTypeBuilder<Payroll> p)
        {
            p.ToTable("PayrollInfo", "dbo")
               .HasKey(p => p.Id);

            p.Property(p => p.Id)
                .HasColumnName("PayrollId")
                .UseIdentityColumn();

            p.Property(p => p.Month)
                .IsRequired();

            p.Property(p => p.Year)
                .IsRequired();

            p.Property(p => p.BaseSalary)
                .HasColumnType("Decimal")
                .IsRequired();

            p.Property(p => p.Allowance)
                .HasColumnType("Decimal")
                .IsRequired();

            p.Property(p => p.Deductions)
                .HasColumnType("Decimal")
                .IsRequired();

            p.Property(p => p.Currency)
                .HasDefaultValue("EGP")
                .HasMaxLength(100)
                .IsRequired();

            p.Property(p => p.Notes)
                .HasColumnType("varchar")
                .HasMaxLength(100);


            //Relation With Employee 

            p.HasOne(p => p.Employee)
            .WithMany(e => e.Payrolls)
            .HasForeignKey(p => p.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
