using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.BLL.DTOs;

public class CreateApplicationDto
{
    public int CandidateID { get; set; }

    public int RequisitionID { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;
}
