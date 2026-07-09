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

public class CandidateService : ICandidateService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICandidateBusinessRules _businessRules;

    public CandidateService(
        IUnitOfWork unitOfWork,
        ICandidateBusinessRules businessRules)
    {
        _unitOfWork = unitOfWork;
        _businessRules = businessRules;
    }

    public async Task<IEnumerable<CandidateDto>> GetAllAsync()
    {
        var candidates = await _unitOfWork.Candidates.GetAllWithPersonAsync();

        return candidates.Select(c => c.ToDto());
    }

    public async Task<CandidateDto?> GetByIdAsync(int id)
    {
        var candidate = await _unitOfWork.Candidates.GetByIdWithPersonAsync(id);

        return candidate?.ToDto();
    }

    public async Task<CandidateDto> AddAsync(CreateCandidateDto dto)
    {
        await _businessRules.ValidateCreateAsync(dto);

        var candidate = dto.ToEntity();

        await _unitOfWork.Candidates.AddAsync(candidate);

        await _unitOfWork.SaveChangesAsync();

        return candidate.ToDto();
    }

    public async Task<bool> UpdateAsync(UpdateCandidateDto dto)
    {
        await _businessRules.ValidateUpdateAsync(dto);

        var candidate = await _unitOfWork.Candidates.GetByIdAsync(dto.Id);

        if (candidate is null)
            return false;

        candidate.PersonId = dto.PersonId;
        candidate.ResumeLink = dto.ResumeLink;
        candidate.JobRequisition = dto.JobRequisition;

        _unitOfWork.Candidates.Update(candidate);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var candidate = await _unitOfWork.Candidates.GetByIdAsync(id);

        if (candidate is null)
            return false;

        _unitOfWork.Candidates.Delete(candidate);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
