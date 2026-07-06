using HRManagementSystem.Enums;
using HRManagementSystem.Models;

namespace HRManagementSystemMSConsole.Models;

public class JobRequisition : BaseEntity
{
    public int EmployeeID { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Headcount { get; set; }
    public JobRequisitionStatus Status { get; set; }
    public int DepartmentID { get; set; }

    //Navigation Properties

    public Department? Department { get; set; }

    public ICollection<Application> Applications { get; set; } = new List<Application>();
}
