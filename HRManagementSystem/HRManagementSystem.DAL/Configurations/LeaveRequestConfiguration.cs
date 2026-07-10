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
    internal class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveRequest> l)
        {
            l.ToTable("LeaveRequestInfo")
                .HasKey(l => l.Id);

            l.Property(l => l.Id)
                .HasColumnName("LeaveRequestID")
                .UseIdentityColumn();

            l.Property(l => l.Type)
                .HasColumnName("LeaveRequestType")
                .HasConversion<string>()
                .HasMaxLength(100);

            l.Property(l => l.OtherTypeDescription)
                .HasColumnName("OtherTypeDescription")
                .HasColumnType("varchar")
                .HasMaxLength(500);

            l.Property(l => l.StartDate)
                .HasColumnName("LeaveRequestStartDate")
                .HasColumnType("Date")
                .IsRequired();

            l.Property(l => l.EndDate)
                .HasColumnName("LeaveRequestEndDate")
                .HasColumnType("Date")
                .IsRequired();

            l.Property(l => l.ManagerStatus)
                .HasColumnName("LeaveRequestManagerStatus")
                .HasConversion<string>()
                .HasMaxLength(100);

            l.Property(l => l.HrStatus)
                .HasColumnName("LeaveRequestHrStatus")
                .HasConversion<string>()
                .HasMaxLength(100);

            l.Property(l => l.Comment)
                .HasColumnName("LeaveRequestComment")
                .HasColumnType("varchar")
                .HasMaxLength(200);


            ////Relation With Employee 

            l.HasOne(l => l.Employee)
            .WithMany(e => e.LeaveRequests)
            .HasForeignKey(l => l.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
