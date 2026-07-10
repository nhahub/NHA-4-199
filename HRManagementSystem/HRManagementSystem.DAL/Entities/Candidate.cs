using HRManagementSystem.Models;

namespace HRManagementSystemMSConsole.Models;

public class Candidate : BaseEntity
{
    public string ResumeLink { get; set; } = string.Empty;
    public int PersonId { get; set; }
    public string JobRequisition { get; set; } = string.Empty;


    public ICollection<Application> Applications { get; set; } = new List<Application>();
    public Person Person { get; set; }
}
