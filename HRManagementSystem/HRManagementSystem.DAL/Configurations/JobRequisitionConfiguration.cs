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
    internal class JobRequisitionConfiguration : IEntityTypeConfiguration<JobRequisition>

    {
        public void Configure(EntityTypeBuilder<JobRequisition> j)
        {
            j.ToTable("JobRequisitionInfo")
                .HasKey(j => j.Id);

            j.Property(j => j.Id)
                .HasColumnName("JobRequisitionId")
                .UseIdentityColumn();

            j.Property(j => j.Title)
                .HasColumnName("JobRequisitionTitle")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            j.Property(j => j.Description)
                .HasColumnName("JobRequisitionDescription")
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .IsRequired();

            j.Property(j => j.Headcount)
                .HasColumnName("JobRequisitionHeadCount")
                .IsRequired();

            j.Property(j => j.Status)
                .HasColumnName("JobRequisitionStatus")
                .HasConversion<string>()
                .HasMaxLength(50)
                .IsRequired();


            // Relation With Department

            j.HasOne(j => j.Department)
            .WithMany(d => d.JobRequisitions)
            .HasForeignKey(j => j.DepartmentID)
            .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
