using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Configurations;

internal class HiringHistoryConfiguration : IEntityTypeConfiguration<HiringHistory>
{
    public void Configure(EntityTypeBuilder<HiringHistory> h)
    {
        h.ToTable("HiringHistoryInfo", "dbo")
            .HasKey(h => h.Id);

        h.Property(h => h.Id)
            .HasColumnName("HiringHistoryID")
            .UseIdentityColumn();

        h.Property(h => h.ApplicationId)
            .HasColumnName("ApplicationId")
            .IsRequired();

        h.Property(h => h.EmployeeId)
            .HasColumnName("EmployeeId")
            .IsRequired();

        h.Property(h => h.ApprovedByEmployeeId)
            .HasColumnName("ApprovedByEmployeeId")
            .IsRequired();

        h.Property(h => h.ApprovedDate)
            .HasColumnName("ApprovedDate")
            .HasColumnType("datetime")
            .IsRequired();

        h.Property(h => h.Decision)
            .HasColumnName("Decision")
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        h.Property(h => h.Notes)
            .HasColumnName("Notes")
            .HasColumnType("varchar")
            .HasMaxLength(500);

        // Application -> HiringHistory (1 : 1)
        h.HasOne(h => h.Application)
            .WithOne(a => a.HiringHistory)
            .HasForeignKey<HiringHistory>(h => h.ApplicationId)
            .OnDelete(DeleteBehavior.NoAction);

        // Employee -> HiringHistory (Employee hired)
        h.HasOne(h => h.Employee)
            .WithMany(e => e.EmployeeHiringHistories)
            .HasForeignKey(h => h.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);

        // Approved By Employee
        h.HasOne(h => h.ApprovedByEmployee)
            .WithMany(e => e.ApprovedHiringHistories)
            .HasForeignKey(h => h.ApprovedByEmployeeId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
