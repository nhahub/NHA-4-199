using HRManagementSystem.BLL.DTOs;
using HRManagementSystem.BLL.Exceptions;
using HRManagementSystem.BLL.Interfaces;
using HRManagementSystem.ViewModels.Candidate;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Controllers;

public class CandidateController : BaseController
{
    private readonly ICandidateService _candidateService;

    public CandidateController(ICandidateService candidateService)
    {
        _candidateService = candidateService;
    }

    public async Task<IActionResult> Index()
    {
        var candidates = await _candidateService.GetAllAsync();

        return View(candidates);
    }

    public IActionResult Create()
    {
        return View(new CreateCandidateViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateCandidateViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var dto = new CreateCandidateDto
        {
            PersonId = model.PersonId,
            ResumeLink = model.ResumeLink,
            JobRequisition = model.JobRequisition
        };

        try
        {
            await _candidateService.AddAsync(dto);

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
        var candidate = await _candidateService.GetByIdAsync(id);

        if (candidate is null)
            return NotFound();

        return View(candidate);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var candidate = await _candidateService.GetByIdAsync(id);

        if (candidate is null)
            return NotFound();

        var model = new UpdateCandidateViewModel
        {
            Id = candidate.Id,
            PersonId = candidate.PersonId,
            ResumeLink = candidate.ResumeLink,
            JobRequisition = candidate.JobRequisition
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateCandidateViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var dto = new UpdateCandidateDto
        {
            Id = model.Id,
            PersonId = model.PersonId,
            ResumeLink = model.ResumeLink,
            JobRequisition = model.JobRequisition
        };

        try
        {
            var updated = await _candidateService.UpdateAsync(dto);

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
        var candidate = await _candidateService.GetByIdAsync(id);

        if (candidate is null)
            return NotFound();

        return View(candidate);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var deleted = await _candidateService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return RedirectToAction(nameof(Index));
    }
}