using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.BLL.DTOs;

namespace HRManagementSystem.BLL.Interfaces;

public interface IApplicationService
{
    Task<IEnumerable<ApplicationDto>> GetAllAsync();

    Task<ApplicationDto?> GetByIdAsync(int id);

    Task<ApplicationDto> AddAsync(CreateApplicationDto dto);

    Task<bool> UpdateAsync(UpdateApplicationDto dto);

    Task<bool> DeleteAsync(int id);
}
