using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.BLL.DTOs.Employee;

namespace HRManagementSystem.BLL.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeLookupDto>> GetManagersAsync();
}
