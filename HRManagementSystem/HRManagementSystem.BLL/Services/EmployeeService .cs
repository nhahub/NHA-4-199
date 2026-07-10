using HRManagementSystem.BLL.Interfaces;
using HRManagementSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.DAL.Repositories;
using HRManagementSystem.DAL;
namespace HRManagementSystem.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public List<Employee> GetAll()
        {
            return _repository.GetAll();
        }

        public Employee GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(Employee employee)
        {
            //if (string.IsNullOrWhiteSpace(employee))
            //    throw new Exception("Employee Name is Required");

            //if (employee.Salary <= 0)
            //    throw new Exception("Salary must be greater than zero");

            _repository.Add(employee);
        }

        public void Update(Employee employee)
        {
            _repository.Update(employee);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
