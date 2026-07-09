using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.BLL.DTOs;

namespace HRManagementSystem.BLL.Interfaces;

public interface ICandidateService
{
    Task<IEnumerable<CandidateDto>> GetAllAsync();

    Task<CandidateDto?> GetByIdAsync(int id);

    Task<CandidateDto> AddAsync(CreateCandidateDto dto);

    Task<bool> UpdateAsync(UpdateCandidateDto dto);

    Task<bool> DeleteAsync(int id);
}
