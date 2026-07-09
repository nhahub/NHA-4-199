using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Configurations;

internal class InterviewConfiguration : IEntityTypeConfiguration<Interview>
{
    public void Configure(EntityTypeBuilder<Interview> i)
    {
        i.ToTable("InterviewInfo", "dbo")
            .HasKey(i => i.Id);

        i.Property(i => i.Id)
            .HasColumnName("InterviewID")
            .UseIdentityColumn();

        i.Property(i => i.RoundNumber)
            .HasColumnName("InterviewRound")
            .IsRequired();

        i.Property(i => i.InterviewType)
            .HasColumnName("InterviewType")
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        i.Property(i => i.InterviewDate)
            .HasColumnName("InterviewDate")
            .HasColumnType("datetime")
            .IsRequired();

        i.Property(i => i.Result)
            .HasColumnName("InterviewResult")
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        i.Property(i => i.Notes)
            .HasColumnName("InterviewNotes")
            .HasColumnType("varchar")
            .HasMaxLength(500);

        // FK -> Application

        i.HasOne(i => i.Application)
            .WithMany(a => a.Interviews)
            .HasForeignKey(i => i.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);

        // FK -> Employee (Interviewer)

        i.HasOne(i => i.Interviewer)
            .WithMany(e => e.Interviews)
            .HasForeignKey(i => i.InterviewerEmployeeId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
