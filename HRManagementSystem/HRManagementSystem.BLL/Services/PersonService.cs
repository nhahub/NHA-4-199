using HRManagementSystem.BLL.BusinessRules.Interfaces;
using HRManagementSystem.BLL.DTOs;
using HRManagementSystem.BLL.Interfaces;
using HRManagementSystem.BLL.Mappings;
using HRManagementSystem.DAL.Entities;
using HRManagementSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.BLL.Services;

public class PersonService : IPersonService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPersonBusinessRules _businessRules;

    public PersonService(
        IUnitOfWork unitOfWork,
        IPersonBusinessRules businessRules)
    {
        _unitOfWork = unitOfWork;
        _businessRules = businessRules;
    }

    public async Task<IEnumerable<PersonDto>> GetAllAsync()
    {
        var persons = await _unitOfWork.Persons.GetAllAsync();

        return persons.Select(person => new PersonDto
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Email = person.Email,
            Phone = person.Phone,
            Address = person.Address,
            DateOfBirth = person.DateOfBirth,
            Gender = person.Gender.ToString()
        });
    }

    public async Task<PersonDto?> GetByIdAsync(int id)
    {
        var person = await _unitOfWork.Persons.GetByIdAsync(id);

        if (person is null)
            return null;

        return person.ToDto();
    }

    public async Task<PersonDto> AddAsync(CreatePersonDto dto)
    {
        await _businessRules.ValidateCreateAsync(dto);

        var person = dto.ToEntity();

        await _unitOfWork.Persons.AddAsync(person);

        await _unitOfWork.SaveChangesAsync();

        return new PersonDto
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Email = person.Email,
            Phone = person.Phone,
            Address = person.Address,
            DateOfBirth = person.DateOfBirth,
            Gender = person.Gender.ToString()
        };
    }

    public async Task<bool> UpdateAsync(UpdatePersonDto dto)
    {
        await _businessRules.ValidateUpdateAsync(dto);

        var person = await _unitOfWork.Persons.GetByIdAsync(dto.Id);

        if (person is null)
            return false;

        person.FirstName = dto.FirstName;
        person.LastName = dto.LastName;
        person.Email = dto.Email;
        person.Phone = dto.Phone;
        person.Address = dto.Address;
        person.DateOfBirth = dto.DateOfBirth;
        person.Gender = dto.Gender;

        _unitOfWork.Persons.Update(person);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var person = await _unitOfWork.Persons.GetByIdAsync(id);

        if (person is null)
            return false;

        _unitOfWork.Persons.Delete(person);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
