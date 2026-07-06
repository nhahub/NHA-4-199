using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.Enums;
using HRManagementSystem.Models;

namespace HRManagementSystemMSConsole.Models;

public class Interview : BaseEntity
{
    public int ApplicationId { get; set; }

    public int InterviewerEmployeeId { get; set; }

    public int RoundNumber { get; set; }

    public InterviewType InterviewType { get; set; }

    public DateTime InterviewDate { get; set; }

    public InterviewResult Result { get; set; }

    public string? Notes { get; set; }

    // Navigation Properties

    public Application? Application { get; set; }

    public Employee? Interviewer { get; set; }
}