using System.ComponentModel.DataAnnotations;
using HRManagementSystem.Enums;

namespace HRManagementSystem.ViewModels.Application;

public class UpdateApplicationViewModel
{
    public int Id { get; set; }

    [Required]
    public AplicationStatus Status { get; set; }

    [Required]
    public JopStage Stage { get; set; }
}
