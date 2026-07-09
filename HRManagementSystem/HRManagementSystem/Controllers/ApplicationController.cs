using HRManagementSystem.BLL.DTOs;
using HRManagementSystem.BLL.Exceptions;
using HRManagementSystem.BLL.Interfaces;
using HRManagementSystem.ViewModels.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRManagementSystem.Controllers;

public class ApplicationController : BaseController
{
    private readonly IApplicationService _applicationService;
    private readonly ICandidateService _candidateService;
    private readonly IJobRequisitionService _jobService;

    public ApplicationController(
        IApplicationService applicationService,
        ICandidateService candidateService,
        IJobRequisitionService jobService)
    {
        _applicationService = applicationService;
        _candidateService = candidateService;
        _jobService = jobService;
    }

    public async Task<IActionResult> Index()
    {
        var applications = await _applicationService.GetAllAsync();

        return View(applications);
    }

    public async Task<IActionResult> Create()
    {
        var model = new CreateApplicationViewModel();

        var candidates = await _candidateService.GetAllAsync();

        model.Candidates = candidates.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = $"{c.PersonName}"
        });

        var jobs = await _jobService.GetAllAsync();

        model.Requisitions = jobs.Select(j => new SelectListItem
        {
            Value = j.Id.ToString(),
            Text = j.Title
        });

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateApplicationViewModel model)
    {
        if (!ModelState.IsValid)
        {
            await LoadDropDowns(model);
            return View(model);
        }

        var dto = new CreateApplicationDto
        {
            CandidateID = model.CandidateID,
            RequisitionID = model.RequisitionID
        };

        try
        {
            await _applicationService.AddAsync(dto);

            return RedirectToAction(nameof(Index));
        }
        catch (BusinessRuleException ex)
        {
            AddBusinessError(ex);

            await LoadDropDowns(model);

            return View(model);
        }
    }

    private async Task LoadDropDowns(CreateApplicationViewModel model)
    {
        var candidates = await _candidateService.GetAllAsync();

        model.Candidates = candidates.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.PersonName
        });

        var jobs = await _jobService.GetAllAsync();

        model.Requisitions = jobs.Select(j => new SelectListItem
        {
            Value = j.Id.ToString(),
            Text = j.Title
        });
    }

    public async Task<IActionResult> Details(int id)
    {
        var application = await _applicationService.GetByIdAsync(id);

        if (application is null)
            return NotFound();

        return View(application);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var application = await _applicationService.GetByIdAsync(id);

        if (application is null)
            return NotFound();

        var vm = new UpdateApplicationViewModel
        {
            Id = application.Id,
            Status = application.Status,
            Stage = application.Stage
        };

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateApplicationViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var dto = new UpdateApplicationDto
        {
            Id = model.Id,
            Status = model.Status,
            Stage = model.Stage
        };

        var updated = await _applicationService.UpdateAsync(dto);

        if (!updated)
            return NotFound();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var application = await _applicationService.GetByIdAsync(id);

        if (application is null)
            return NotFound();

        return View(application);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var deleted = await _applicationService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return RedirectToAction(nameof(Index));
    }
}