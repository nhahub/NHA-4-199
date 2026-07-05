using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Configurations
{
    internal class WorkShiftConfiguration : IEntityTypeConfiguration<WorkShift>
    {
        public void Configure(EntityTypeBuilder<WorkShift> w)
        {
            w.ToTable("WorkShiftInfo")
                .HasKey(w => w.Id);

            w.Property(w => w.Id)
                .HasColumnName("WorkShiftID")
                .UseIdentityColumn();

            w.Property(w => w.StartTime)
                .HasColumnType("time")
                .IsRequired();

            w.Property(w => w.EndTime)
                .HasColumnType("time")
                .IsRequired();

            w.Property(w => w.GracePeriod)
               .IsRequired();

            w.Property(w => w.LateThresholdMinutes)
              .IsRequired();

            w.Property(w => w.HalfDayThresholdMinutes)
              .IsRequired();
        }
    }
}
