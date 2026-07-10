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
using HRManagementSystem.Enums;

namespace HRManagementSystem.BLL.BusinessRules;

public class JobRequisitionBusinessRules : IJobRequisitionBusinessRules
{
    private readonly IValidator<CreateJobRequisitionDto> _createValidator;
    private readonly IValidator<UpdateJobRequisitionDto> _updateValidator;
    private readonly IUnitOfWork _unitOfWork;

    public JobRequisitionBusinessRules(
        IValidator<CreateJobRequisitionDto> createValidator,
        IValidator<UpdateJobRequisitionDto> updateValidator,
        IUnitOfWork unitOfWork)
    {
        _createValidator = createValidator;
        _updateValidator = updateValidator;
        _unitOfWork = unitOfWork;
    }

    public async Task ValidateCreateAsync(CreateJobRequisitionDto dto)
    {
        await _createValidator.ValidateAndThrowAsync(dto);

        var department =
            await _unitOfWork.Departments.GetByIdAsync(dto.DepartmentID);

        if (department is null)
            throw new BusinessRuleException("Department does not exist.");

        var exists = await _unitOfWork.JobRequisitions.AnyAsync(j =>
        j.DepartmentID == dto.DepartmentID &&
        j.Title == dto.Title &&
        j.Status == JobRequisitionStatus.Open);

        if (exists)
        {
            throw new BusinessRuleException(
                "An open job with the same title already exists in this department.");
        }
    }

    public async Task ValidateUpdateAsync(UpdateJobRequisitionDto dto)
    {
        await _updateValidator.ValidateAndThrowAsync(dto);

        var department =
            await _unitOfWork.Departments.GetByIdAsync(dto.DepartmentID);

        if (department is null)
            throw new BusinessRuleException("Department does not exist.");
    }
}
