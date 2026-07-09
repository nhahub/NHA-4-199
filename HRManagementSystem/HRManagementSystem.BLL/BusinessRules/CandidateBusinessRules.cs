using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using HRManagementSystem.BLL.BusinessRules.Interfaces;
using HRManagementSystem.BLL.DTOs;

namespace HRManagementSystem.BLL.BusinessRules;

public class CandidateBusinessRules : ICandidateBusinessRules
{
    private readonly IValidator<CreateCandidateDto> _createValidator;
    private readonly IValidator<UpdateCandidateDto> _updateValidator;

    public CandidateBusinessRules(
        IValidator<CreateCandidateDto> createValidator,
        IValidator<UpdateCandidateDto> updateValidator)
    {
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    public async Task ValidateCreateAsync(CreateCandidateDto dto)
    {
        await _createValidator.ValidateAndThrowAsync(dto);
    }

    public async Task ValidateUpdateAsync(UpdateCandidateDto dto)
    {
        await _updateValidator.ValidateAndThrowAsync(dto);
    }
}
