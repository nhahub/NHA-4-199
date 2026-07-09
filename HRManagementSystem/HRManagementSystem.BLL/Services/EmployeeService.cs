using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.BLL.DTOs.Employee;
using HRManagementSystem.BLL.Interfaces;
using HRManagementSystem.DAL.Repositories.Interfaces;

namespace HRManagementSystem.BLL.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<EmployeeLookupDto>> GetManagersAsync()
    {
        var employees = await _unitOfWork.Employees.GetManagersAsync();

        return employees.Select(e => new EmployeeLookupDto
        {
            Id = e.Id,
            FullName = $"{e.Person.FirstName} {e.Person.LastName}"
        });
    }
}
