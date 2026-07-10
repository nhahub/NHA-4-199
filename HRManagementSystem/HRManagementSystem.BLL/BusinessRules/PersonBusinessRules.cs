using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.BLL.BusinessRules.Interfaces;
using HRManagementSystem.BLL.DTOs;
using HRManagementSystem.BLL.Exceptions;
using HRManagementSystem.DAL.Repositories.Interfaces;

namespace HRManagementSystem.BLL.BusinessRules;

public class PersonBusinessRules : IPersonBusinessRules
{
    private readonly IUnitOfWork _unitOfWork;

    public PersonBusinessRules(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task ValidateCreateAsync(CreatePersonDto dto)
    {
        if (await _unitOfWork.Persons.AnyAsync(p => p.Email == dto.Email))
            throw new BusinessRuleException("Email already exists.");
    }

    public async Task ValidateUpdateAsync(UpdatePersonDto dto)
    {
        if (await _unitOfWork.Persons.AnyAsync(p =>
                p.Email == dto.Email && p.Id != dto.Id))
        {
            throw new BusinessRuleException("Email already exists.");
        }
    }
}
