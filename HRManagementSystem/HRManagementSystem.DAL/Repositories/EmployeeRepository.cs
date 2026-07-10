using HRManagementSystem.DAL.Context;
using HRManagementSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.DAL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(HRDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Employee>> GetManagersAsync()
        {
            return await _context.Employees
                .Include(e => e.Person)
                .Where(e => e.EmployeesManaged.Any())
                .ToListAsync();
        }
        public async Task<IEnumerable<Employee>> GetAllWithDetailsAsync()
        {
            return await _context.Employees
                .Include(e => e.Person)
                .Include(e => e.Department)
                .ToListAsync();
        }
        public async Task<Employee?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.Person)
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}