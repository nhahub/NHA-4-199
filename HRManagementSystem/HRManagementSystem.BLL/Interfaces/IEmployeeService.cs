using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HRManagementSystem.BLL.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();

        Employee GetById(int id);

using HRManagementSystem.BLL.DTOs.Employee;
        void Add(Employee employee);

namespace HRManagementSystem.BLL.Interfaces;
        void Update(Employee employee);

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeLookupDto>> GetManagersAsync();
        void Delete(int id);
    }
}
