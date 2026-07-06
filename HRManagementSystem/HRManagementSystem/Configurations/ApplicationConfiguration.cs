using HRManagementSystemMSConsole.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Configurations
{
    internal class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Application> a)
        {
            a.ToTable("ApplicationInfo", "dbo")
                .HasKey(a => a.Id);

            a.Property(a => a.Id)
                .HasColumnName("ApplicationID")
                .UseIdentityColumn();

            a.Property(a => a.Date)
                .HasColumnName("ApplicationDate")
                .HasColumnType("Date")
                .IsRequired();

            a.Property(a => a.Status)
                .HasColumnName("Apllicationstatus")
                .HasConversion<string>()
                .HasMaxLength(50);

            a.Property(a => a.Stage)
                .HasColumnName("ApllicationStage")
                .HasConversion<string>()
                .HasMaxLength(50);





            //Relation With Candidate

            a.HasOne(a => a.Candidate)
            .WithMany(c => c.Applications)
            .HasForeignKey(a => a.CandidateID)
            .OnDelete(DeleteBehavior.NoAction);

            //Relation With JopRequistation

            a.HasOne(a => a.JobRequisition)
            .WithMany(j => j.Applications)
            .HasForeignKey(a => a.RequisitionID)
            .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
