
using HRManagementSystem.Models;

public class Attendance : BaseEntity
{
    public int EmployeeID { get; set; }
    public DateTime Date { get; set; }

    public DateTime? CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }

    public AttendanceStatus Status { get; set; }


    public int ShiftID { get; set; }

    public CheckInSource Source { get; set; }

    //Navigation Properties

    public required Employee Employee { get; set; }

    public required WorkShift WorkShift { get; set; }
}