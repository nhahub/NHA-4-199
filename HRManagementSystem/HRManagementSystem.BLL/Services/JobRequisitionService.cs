using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.BLL.BusinessRules.Interfaces;
using HRManagementSystem.BLL.DTOs;
using HRManagementSystem.BLL.Interfaces;
using HRManagementSystem.BLL.Mappings;
using HRManagementSystem.DAL.Repositories.Interfaces;

namespace HRManagementSystem.BLL.Services;

public class JobRequisitionService : IJobRequisitionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJobRequisitionBusinessRules _businessRules;

    public JobRequisitionService(
        IUnitOfWork unitOfWork,
        IJobRequisitionBusinessRules businessRules)
    {
        _unitOfWork = unitOfWork;
        _businessRules = businessRules;
    }

    public async Task<IEnumerable<JobRequisitionDto>> GetAllAsync()
    {
        var jobs = await _unitOfWork.JobRequisitions.GetAllAsync();

        return jobs.Select(job => job.ToDto());
    }

    public async Task<JobRequisitionDto?> GetByIdAsync(int id)
    {
        var job = await _unitOfWork.JobRequisitions.GetByIdAsync(id);

        if (job is null)
            return null;

        return job.ToDto();
    }

    public async Task<JobRequisitionDto> AddAsync(CreateJobRequisitionDto dto)
    {
        await _businessRules.ValidateCreateAsync(dto);

        var job = dto.ToEntity();

        await _unitOfWork.JobRequisitions.AddAsync(job);

        await _unitOfWork.SaveChangesAsync();

        return job.ToDto();
    }

    public async Task<bool> UpdateAsync(UpdateJobRequisitionDto dto)
    {
        await _businessRules.ValidateUpdateAsync(dto);

        var job = await _unitOfWork.JobRequisitions.GetByIdAsync(dto.Id);

        if (job is null)
            return false;

        job.EmployeeID = dto.EmployeeID;
        job.Title = dto.Title;
        job.Description = dto.Description;
        job.Headcount = dto.Headcount;
        job.Status = dto.Status;
        job.DepartmentID = dto.DepartmentID;

        _unitOfWork.JobRequisitions.Update(job);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var job = await _unitOfWork.JobRequisitions.GetByIdAsync(id);

        if (job is null)
            return false;

        _unitOfWork.JobRequisitions.Delete(job);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
