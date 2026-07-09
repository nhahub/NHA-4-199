using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.BLL.DTOs;

namespace HRManagementSystem.BLL.Interfaces;

public interface IJobRequisitionService
{
    Task<IEnumerable<JobRequisitionDto>> GetAllAsync();

    Task<JobRequisitionDto?> GetByIdAsync(int id);

    Task<JobRequisitionDto> AddAsync(CreateJobRequisitionDto dto);

    Task<bool> UpdateAsync(UpdateJobRequisitionDto dto);

    Task<bool> DeleteAsync(int id);
}
