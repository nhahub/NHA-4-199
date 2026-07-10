using HRManagementSystem.DAL.Entities;
using HRManagementSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    Task<IEnumerable<Employee>> GetManagersAsync();
    Task<IEnumerable<Employee>> GetAllWithDetailsAsync();
    Task<Employee?> GetByIdWithDetailsAsync(int id);
}
