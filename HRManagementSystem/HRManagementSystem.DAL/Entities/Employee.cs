using HRManagementSystem.DAL.Entities;
using HRManagementSystem.Enums;
using HRManagementSystem.DAL.Entities;

namespace HRManagementSystem.DAL.Entities
{
    public class Employee : BaseEntity
    {

        public Employee()
        {

        }
        public DateTime HireDate { get; set; }
        public DateTime? EFF_Start { get; set; }
        public DateTime? EFF_End { get; set; }
        public decimal BasicSalary { get; set; }
        public string? ApplicationUserId { get; set; }
        public int PersonId { get; set; }
        public int DepartmentId { get; set; }
        public int? ManagerId { get; set; }

        //Navigation Properties

        public required Department Department { get; set; }
        public Person Person { get; set; }

        public Employee? Manager { get; set; }

        public ICollection<Employee> EmployeesManaged { get; set; } = new List<Employee>();

        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

        public ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();

        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();

        public ICollection<JobRequisition> JobRequisitions { get; set; } = new List<JobRequisition>();
        public ICollection<Interview> Interviews { get; set; } = new List<Interview>();
        // ???????? ???? ?? ???? ??? ???????
        public ICollection<HiringHistory> ApprovedHiringHistories { get; set; } = new List<HiringHistory>();

    // ??? ????? ?????? ????
    public ICollection<HiringHistory> EmployeeHiringHistories { get; set; } = new List<HiringHistory>();
    public virtual ApplicationUser? User { get; set; }

}
}