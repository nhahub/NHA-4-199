using HRManagementSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.DAL.Entities
{
    public class Department : BaseEntity
    {
        public required  string Name { get; set; }
        public string? Description { get; set; }
        public required int ManagerId { get; set; }

        public int EmployeeCount { get; set; }

        //Navigation Properties
        public Employee? Manager { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

        public ICollection<JobRequisition> JobRequisitions { get; set; } = new List<JobRequisition>();

    }

}
