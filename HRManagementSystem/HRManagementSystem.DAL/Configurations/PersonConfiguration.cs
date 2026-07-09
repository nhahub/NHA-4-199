using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using HRManagementSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Configurations;
public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        // اسم الجدول
        builder.ToTable("Persons");

        // First Name
        builder.Property(p => p.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        // Last Name
        builder.Property(p => p.LastName)
            .IsRequired()
            .HasMaxLength(100);

        // Email
        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasIndex(p => p.Email)
            .IsUnique();

        // Phone
        builder.Property(p => p.Phone)
            .IsRequired()
            .HasMaxLength(20);

        // Address
        builder.Property(p => p.Address)
            .IsRequired()
            .HasMaxLength(500);

        // DateOfBirth
        builder.Property(p => p.DateOfBirth)
            .IsRequired();

        // Gender (Enum to String)
        builder.Property(p => p.Gender)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(10);
    }
}
