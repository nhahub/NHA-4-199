using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.Enums;

namespace HRManagementSystem.BLL.DTOs;

public class ApplicationDto
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public AplicationStatus Status { get; set; }

    public JopStage Stage { get; set; }

    public int CandidateID { get; set; }

    public int RequisitionID { get; set; }

    public string CandidateName { get; set; } = string.Empty;

    public string JobTitle { get; set; } = string.Empty;
}
