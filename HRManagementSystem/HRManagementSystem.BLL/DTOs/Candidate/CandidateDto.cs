using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.BLL.DTOs;

public class CandidateDto
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public string PersonName { get; set; } = string.Empty;

    public string ResumeLink { get; set; } = string.Empty;

    public string JobRequisition { get; set; } = string.Empty;
}
