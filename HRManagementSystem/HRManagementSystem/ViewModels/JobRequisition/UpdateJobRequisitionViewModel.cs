using HRManagementSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.ViewModels.JobRequisition;

public class UpdateJobRequisitionViewModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int EmployeeID { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue)]
    public int Headcount { get; set; }

    [Required]
    public JobRequisitionStatus Status { get; set; }

    [Required]
    public int DepartmentID { get; set; }
}
