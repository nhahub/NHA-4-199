using HRManagementSystem.BLL.Interfaces;
using HRManagementSystem.DAL.Entities;

namespace HRManagementSystem.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetManagersAsync()
        {
            return await _employeeRepository.GetManagersAsync();
        }

        public async Task AddAsync(Employee employee)
        {
            await _employeeRepository.AddAsync(employee);
        }

        public async Task UpdateAsync(Employee employee)
        {
            _employeeRepository.Update(employee);
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                throw new Exception("Employee not found");

            _employeeRepository.Delete(employee);
        }
    }
}