using HRManagementSystem.BLL.BusinessRules.Interfaces;
using HRManagementSystem.BLL.DTOs;
using HRManagementSystem.BLL.Interfaces;
using HRManagementSystem.BLL.Mappings;
using HRManagementSystem.DAL.Entities;
using HRManagementSystem.DAL.Repositories.Interfaces;
using HRManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HRManagementSystem.BLL.Services;

public class ApplicationService : IApplicationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IApplicationBusinessRules _businessRules;

    public ApplicationService(
        IUnitOfWork unitOfWork,
        IApplicationBusinessRules businessRules)
    {
        _unitOfWork = unitOfWork;
        _businessRules = businessRules;
    }

    public async Task<IEnumerable<ApplicationDto>> GetAllAsync()
    {
        var applications = await _unitOfWork.Applications.GetAllWithDetailsAsync();

        return applications.Select(a => a.ToDto());
    }

    public async Task<ApplicationDto?> GetByIdAsync(int id)
    {
        var application = await _unitOfWork.Applications.GetByIdWithDetailsAsync(id);

        return application?.ToDto();
    }

    public async Task<ApplicationDto> AddAsync(CreateApplicationDto dto)
    {
        await _businessRules.ValidateCreateAsync(dto);

        var application = new Application
        {
            CandidateID = dto.CandidateID,
            RequisitionID = dto.RequisitionID,

            Date = dto.Date,

            Status = AplicationStatus.Pending,

            Stage = JopStage.Sourcing
        };

        await _unitOfWork.Applications.AddAsync(application);

        await _unitOfWork.SaveChangesAsync();

        return application.ToDto();
    }

    public async Task<bool> UpdateAsync(UpdateApplicationDto dto)
    {
        await _businessRules.ValidateUpdateAsync(dto);

        var application =
            await _unitOfWork.Applications.GetByIdAsync(dto.Id);

        if (application is null)
            return false;

        application.Status = dto.Status;
        application.Stage = dto.Stage;

        _unitOfWork.Applications.Update(application);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var application =
            await _unitOfWork.Applications.GetByIdAsync(id);

        if (application is null)
            return false;

        _unitOfWork.Applications.Delete(application);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
