using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.DAL.Entities;

namespace HRManagementSystem.DAL.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IEmployeeRepository Employees { get; }
    IGenericRepository<Department> Departments { get; }
    IGenericRepository<Candidate> Candidates { get; }
    IGenericRepository<Application> Applications { get; }
    IGenericRepository<JobRequisition> JobRequisitions { get; }
    IGenericRepository<Attendance> Attendances { get; }
    IGenericRepository<Payroll> Payrolls { get; }
    IGenericRepository<LeaveRequest> LeaveRequests { get; }
    IGenericRepository<WorkShift> WorkShifts { get; }
    IGenericRepository<Person> Persons { get; }
    IGenericRepository<Interview> Interviews { get; }
    IGenericRepository<HiringHistory> HiringHistories { get; }

    Task<int> SaveChangesAsync();
}
