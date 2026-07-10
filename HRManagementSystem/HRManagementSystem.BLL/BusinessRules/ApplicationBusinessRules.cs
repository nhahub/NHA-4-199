using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using HRManagementSystem.BLL.BusinessRules.Interfaces;
using HRManagementSystem.BLL.DTOs;
using HRManagementSystem.BLL.Exceptions;
using HRManagementSystem.DAL.Repositories.Interfaces;

namespace HRManagementSystem.BLL.BusinessRules;

public class ApplicationBusinessRules : IApplicationBusinessRules
{
    private readonly IValidator<CreateApplicationDto> _createValidator;
    private readonly IValidator<UpdateApplicationDto> _updateValidator;
    private readonly IUnitOfWork _unitOfWork;

    public ApplicationBusinessRules(
        IValidator<CreateApplicationDto> createValidator,
        IValidator<UpdateApplicationDto> updateValidator,
        IUnitOfWork unitOfWork)
    {
        _createValidator = createValidator;
        _updateValidator = updateValidator;
        _unitOfWork = unitOfWork;
    }

    public async Task ValidateCreateAsync(CreateApplicationDto dto)
    {
        await _createValidator.ValidateAndThrowAsync(dto);

        // Candidate Exists
        var candidate =
            await _unitOfWork.Candidates.GetByIdAsync(dto.CandidateID);

        if (candidate is null)
            throw new BusinessRuleException("Candidate does not exist.");

        // Job Exists
        var job =
            await _unitOfWork.JobRequisitions.GetByIdAsync(dto.RequisitionID);

        if (job is null)
            throw new BusinessRuleException("Job Requisition does not exist.");

        // Candidate already applied
        var applications =
            await _unitOfWork.Applications.FindAsync(a =>
                a.CandidateID == dto.CandidateID &&
                a.RequisitionID == dto.RequisitionID);

        if (applications.Any())
            throw new BusinessRuleException(
                "Candidate has already applied for this job.");
    }

    public async Task ValidateUpdateAsync(UpdateApplicationDto dto)
    {
        await _updateValidator.ValidateAndThrowAsync(dto);
    }
}
