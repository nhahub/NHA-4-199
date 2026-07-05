using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.Enums;
using HRManagementSystem.Models;

namespace HRManagementSystemMSConsole.Models;

public class HiringHistory : BaseEntity
{
    public int ApplicationId { get; set; }

    public int EmployeeId { get; set; }

    public int ApprovedByEmployeeId { get; set; }

    public DateTime ApprovedDate { get; set; }

    public HiringDecision Decision { get; set; }

    public string? Notes { get; set; }

    // Navigation Properties

    public Application Application { get; set; }

    public Employee Employee { get; set; }

    public Employee ApprovedByEmployee { get; set; }
}
