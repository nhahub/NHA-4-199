using HRManagementSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Configurations
{
    internal class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Attendance> a)
        {
            a.ToTable("AttendanceInfo")
                .HasKey(a => a.Id);

            a.Property(a => a.Id)
                .HasColumnName("AttendanceID")
                .UseIdentityColumn();

            a.Property(a => a.Date)
                .HasColumnName("AttendanceDate")
                .HasColumnType("Date")
                .IsRequired();

            a.Property(a => a.CheckIn)
                .HasColumnName("CheckINAttendance")
                .HasColumnType("Date")
                .IsRequired();

            a.Property(a => a.CheckOut)
                .HasColumnName("CheckOutAttendance")
                .HasColumnType("Date")
                .IsRequired();

            a.Property(a => a.Status)
               .HasColumnName("AttendanceStatus")
               .HasConversion<string>()
                .HasMaxLength(50);

            a.Property(a => a.Source)
              .HasColumnName("AttendanceSource")
              .HasConversion<string>()
               .HasMaxLength(50);


            //Relation with Employee

            a.HasOne(a => a.Employee)
            .WithMany(e => e.Attendances)
            .HasForeignKey(a => a.EmployeeID)
            .OnDelete(DeleteBehavior.NoAction);

            //Relation With WorkShift

            a.HasOne(a => a.WorkShift)
            .WithMany(w => w.Attendances)
            .HasForeignKey(a => a.ShiftID)
            .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
