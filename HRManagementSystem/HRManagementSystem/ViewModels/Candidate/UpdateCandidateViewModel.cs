using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.ViewModels.Candidate;

public class UpdateCandidateViewModel
{
    public int Id { get; set; }

    [Required]
    public int PersonId { get; set; }

    [Required]
    [MaxLength(200)]
    public string ResumeLink { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string JobRequisition { get; set; } = string.Empty;
}
