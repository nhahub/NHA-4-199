using HRManagementSystem.BLL.DTOs;
using HRManagementSystem.BLL.Exceptions;
using HRManagementSystem.BLL.Interfaces;
using HRManagementSystem.ViewModels.Department;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRManagementSystem.Controllers;
public class DepartmentController : Controller
{
    private readonly IDepartmentService _departmentService;
    private readonly IEmployeeService _employeeService;

    public IActionResult Departments()
    {
        return View();
    }

    public IActionResult DepartmentDetails()
    {
        return View();
    }

    public DepartmentController(
      IDepartmentService departmentService,
      IEmployeeService employeeService)
    {
        _departmentService = departmentService;
        _employeeService = employeeService;
    }

    public async Task<IActionResult> Index()
    {
        var departments = await _departmentService.GetAllAsync();

        return View(departments);
    }

    public async Task<IActionResult> Details(int id)
    {
        var department = await _departmentService.GetByIdAsync(id);

        if (department == null)
            return NotFound();

        return View(department);
    }
    public async Task<IActionResult> Create()
    {
        var managers = await _employeeService.GetManagersAsync();

        var model = new CreateDepartmentViewModel
        {
            Managers = managers.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Person.FirstName
            })
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateDepartmentViewModel model)
    {
        if (!ModelState.IsValid)
        {
            var managers = await _employeeService.GetManagersAsync();

            model.Managers = managers.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Person.FirstName
            });

            return View(model);
        }

        var dto = new CreateDepartmentDto
        {
            Name = model.Name,
            Description = model.Description,
            ManagerId = model.ManagerId
        };

        try
        {
            await _departmentService.AddAsync(dto);

            return RedirectToAction(nameof(Index));
        }
        catch (BusinessRuleException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);

            var managers = await _employeeService.GetManagersAsync();

            model.Managers = managers.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Person.FirstName
            });

            return View(model);
        }
    }


    private async Task<IEnumerable<SelectListItem>> GetManagersAsync()
    {
        var managers = await _employeeService.GetManagersAsync();

        return managers.Select(m => new SelectListItem
        {
            Value = m.Id.ToString(),
            Text = m.Person.FirstName
        });
    }
}
