using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.Enums;

namespace HRManagementSystem.BLL.DTOs;

public class CreateJobRequisitionDto
{
    public int EmployeeID { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Headcount { get; set; }

    public JobRequisitionStatus Status { get; set; }

    public int DepartmentID { get; set; }
}
