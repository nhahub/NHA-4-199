using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace HRManagementSystem.ViewModels.Application;

public class CreateApplicationViewModel
{
    [Required]
    public int CandidateID { get; set; }

    [Required]
    public int RequisitionID { get; set; }


    public IEnumerable<SelectListItem> Candidates { get; set; }
        = Enumerable.Empty<SelectListItem>();

    public IEnumerable<SelectListItem> Requisitions { get; set; }
        = Enumerable.Empty<SelectListItem>();
}
