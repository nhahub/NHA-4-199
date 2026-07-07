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
    public class HRDbContext : DbContext
    {
        public HRDbContext(DbContextOptions<HRDbContext> options)
        : base(options)
        {
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
