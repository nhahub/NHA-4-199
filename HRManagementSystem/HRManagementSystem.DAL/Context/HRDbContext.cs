using HRManagementSystem.Configurations;
using HRManagementSystem.DAL.Entities;
using HRManagementSystem.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HRManagementSystem.DAL.Context
{
    public class HRDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public HRDbContext(DbContextOptions<HRDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

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
