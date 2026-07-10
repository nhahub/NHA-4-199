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
    internal class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> c)
        {
            c.ToTable("CandidateInfo", "dbo")
                .HasKey(c => c.Id);

            c.Property(c => c.Id)
                .HasColumnName("CandidateId")
                .UseIdentityColumn();

           

            c.Property(c => c.ResumeLink)
                .HasColumnName("CandidateResume")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            c.Property(c => c.JobRequisition)
                .HasColumnName("CandidateJopRequisition")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            c.Property(c => c.PersonId)
            .HasColumnName("PersonID")
            .IsRequired();




            //Relationship configuration

            c.HasOne(c => c.Person)
            .WithOne(p => p.Candidate)
            .HasForeignKey<Candidate>(c => c.PersonId)
            .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
