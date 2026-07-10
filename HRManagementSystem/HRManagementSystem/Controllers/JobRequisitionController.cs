using HRManagementSystem.BLL.DTOs;
using HRManagementSystem.BLL.Exceptions;
using HRManagementSystem.BLL.Interfaces;
using HRManagementSystem.ViewModels.JobRequisition;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Controllers;
public class JobRequisitionController : BaseController
{
    private readonly IJobRequisitionService _jobService;

    public JobRequisitionController(IJobRequisitionService jobService)
    {
        _jobService = jobService;
    }

    public async Task<IActionResult> Index()
    {
        var jobs = await _jobService.GetAllAsync();

        return View(jobs);
    }

    public IActionResult Create()
    {
        return View(new CreateJobRequisitionViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateJobRequisitionViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var dto = new CreateJobRequisitionDto
        {
            EmployeeID = model.EmployeeID,
            Title = model.Title,
            Description = model.Description,
            Headcount = model.Headcount,
            Status = model.Status,
            DepartmentID = model.DepartmentID
        };

        try
        {
            await _jobService.AddAsync(dto);

            return RedirectToAction(nameof(Index));
        }
        catch (BusinessRuleException ex)
        {
            AddBusinessError(ex);

            return View(model);
        }
    }

    public async Task<IActionResult> Details(int id)
    {
        var job = await _jobService.GetByIdAsync(id);

        if (job is null)
            return NotFound();

        return View(job);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var job = await _jobService.GetByIdAsync(id);

        if (job is null)
            return NotFound();

        var model = new UpdateJobRequisitionViewModel
        {
            Id = job.Id,
            EmployeeID = job.EmployeeID,
            DepartmentID = job.DepartmentID,
            Title = job.Title,
            Description = job.Description,
            Headcount = job.Headcount,
            Status = job.Status
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateJobRequisitionViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var dto = new UpdateJobRequisitionDto
        {
            Id = model.Id,
            EmployeeID = model.EmployeeID,
            DepartmentID = model.DepartmentID,
            Title = model.Title,
            Description = model.Description,
            Headcount = model.Headcount,
            Status = model.Status
        };

        try
        {
            var updated = await _jobService.UpdateAsync(dto);

            if (!updated)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
        catch (BusinessRuleException ex)
        {
            AddBusinessError(ex);
            return View(model);
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        var job = await _jobService.GetByIdAsync(id);

        if (job is null)
            return NotFound();

        return View(job);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var deleted = await _jobService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return RedirectToAction(nameof(Index));
    }
}
