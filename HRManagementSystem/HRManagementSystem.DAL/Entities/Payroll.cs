using HRManagementSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.DAL.Entities
{

    public sealed class Payroll : BaseEntity
    {
        public int EmployeeId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }


        public decimal BaseSalary { get; set; } = 0.0m;
        public decimal Allowance { get; set; } = 0.0m;
        public decimal Deductions { get; set; } = 0.0m;


        public decimal NetSalary => (BaseSalary + Allowance) - Deductions;

        public string Currency { get; set; } = "EGP";
        public string Notes { get; set; } = string.Empty;

        //Navigation property

        public required Employee Employee { get; set; }

        public override bool Equals(object? obj)
        {
            var other = obj as Payroll;
            if (other is null) return false;


            return EmployeeId == other.EmployeeId && Month == other.Month && Year == other.Year;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EmployeeId, Month, Year);
        }
    }

}