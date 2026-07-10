using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.ViewModels.Department;

public class CreateDepartmentViewModel
{
    [Required(ErrorMessage = "Department name is required")]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;


    [MaxLength(500)]
    public string? Description { get; set; }


    [Required(ErrorMessage = "Please select a manager")]
    public int ManagerId { get; set; }


    public IEnumerable<SelectListItem> Managers { get; set; }
        = new List<SelectListItem>();
}
