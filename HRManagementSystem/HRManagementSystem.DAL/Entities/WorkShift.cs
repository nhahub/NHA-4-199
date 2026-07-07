using HRManagementSystem.Models;

public class WorkShift : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }

    public int GracePeriod { get; set; }

    //  Advanced Rules
    public int LateThresholdMinutes { get; set; }     // بعده يبقى Late
    public int HalfDayThresholdMinutes { get; set; }  // بعده يبقى HalfDay

    //Navigation Properties
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}