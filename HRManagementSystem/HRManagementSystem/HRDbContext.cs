using HRManagementSystem.Configurations;
using HRManagementSystem.Models;
using HRManagementSystemMS01.Models;
using HRManagementSystemMSConsole.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem
{
    internal class HRDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-UNL1S0G\\SQLEXPRESS;Initial Catalog=HR;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<JobRequisition> JobRequisitions { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Payroll> Payrolls { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        public DbSet<WorkShift> WorkShifts { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<HiringHistory> HiringHistories { get; set; }


    }
}
