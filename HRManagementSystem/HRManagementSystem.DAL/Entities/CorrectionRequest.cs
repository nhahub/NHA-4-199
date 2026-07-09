using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.DAL.Entities;

public class CorrectionRequest : BaseEntity
{
    public int AttendanceID { get; set; }

    public DateTime? NewCheckIn { get; set; }

    public DateTime? NewCheckOut { get; set; }

    public string? Reason { get; set; }

    public CorrectionStatus Status { get; set; }
}
