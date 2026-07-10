using HRManagementSystem.BLL.DTOs;
using HRManagementSystem.BLL.Exceptions;
using HRManagementSystem.BLL.Interfaces;
using HRManagementSystem.Enums;
using HRManagementSystem.ViewModels.Person;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Controllers;

public class PersonController :  BaseController
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    public async Task<IActionResult> Index()
    {
        var persons = await _personService.GetAllAsync();

        return View(persons);
    }

    public IActionResult Create()
    {
        return View(new CreatePersonViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreatePersonViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var dto = new CreatePersonDto
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Phone = model.Phone,
            Address = model.Address,
            DateOfBirth = model.DateOfBirth,
            Gender = model.Gender
        };

        Console.WriteLine($"Model Date: {model.DateOfBirth:yyyy-MM-dd}");
        Console.WriteLine($"DTO Date: {dto.DateOfBirth:yyyy-MM-dd}");

        try
        {
            await _personService.AddAsync(dto);

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
        var person = await _personService.GetByIdAsync(id);

        if (person is null)
            return NotFound();

        return View(person);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var person = await _personService.GetByIdAsync(id);

        if (person == null)
            return NotFound();

        var model = new UpdatePersonViewModel
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Email = person.Email,
            Phone = person.Phone,
            Address = person.Address,
            DateOfBirth = person.DateOfBirth,
            Gender = Enum.Parse<Gender>(person.Gender)
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdatePersonViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var dto = new UpdatePersonDto
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Phone = model.Phone,
            Address = model.Address,
            DateOfBirth = model.DateOfBirth,
            Gender = model.Gender
        };

        try
        {
            var updated = await _personService.UpdateAsync(dto);

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
        var person = await _personService.GetByIdAsync(id);

        if (person == null)
            return NotFound();

        return View(person);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var deleted = await _personService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return RedirectToAction(nameof(Index));
    }


}
