using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using HRManagementSystem.Enums;

namespace HRManagementSystem.BLL.DTOs;

public class UpdateApplicationDto
{
    public int Id { get; set; }

    public AplicationStatus Status { get; set; }

    public JopStage Stage { get; set; }
}

