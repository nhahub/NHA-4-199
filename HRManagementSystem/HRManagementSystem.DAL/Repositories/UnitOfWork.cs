using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.DAL.Context;
using HRManagementSystem.DAL.Entities;
using HRManagementSystem.DAL.Repositories.Interfaces;

namespace HRManagementSystem.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly HRDbContext _context;

    public IEmployeeRepository Employees { get; }
    public IGenericRepository<Department> Departments { get; }
    public ICandidateRepository Candidates { get; }
    public IApplicationRepository Applications { get; }
    public IGenericRepository<JobRequisition> JobRequisitions { get; }
    public IGenericRepository<Attendance> Attendances { get; }
    public IGenericRepository<Payroll> Payrolls { get; }
    public IGenericRepository<LeaveRequest> LeaveRequests { get; }
    public IGenericRepository<WorkShift> WorkShifts { get; }
    public IGenericRepository<Person> Persons { get; }
    public IGenericRepository<Interview> Interviews { get; }
    public IGenericRepository<HiringHistory> HiringHistories { get; }

    public UnitOfWork(HRDbContext context)
    {
        _context = context;

        //Employees = new EmployeeRepository(_context);
        Departments = new GenericRepository<Department>(_context);
        Candidates = new CandidateRepository(_context);
        Applications = new ApplicationRepository(_context);
        JobRequisitions = new GenericRepository<JobRequisition>(_context);
        Attendances = new GenericRepository<Attendance>(_context);
        Payrolls = new GenericRepository<Payroll>(_context);
        LeaveRequests = new GenericRepository<LeaveRequest>(_context);
        WorkShifts = new GenericRepository<WorkShift>(_context);
        Persons = new GenericRepository<Person>(_context);
        Interviews = new GenericRepository<Interview>(_context);
        HiringHistories = new GenericRepository<HiringHistory>(_context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
