using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.BLL.DTOs;

namespace HRManagementSystem.BLL.Interfaces;

public interface IPersonService
{
    Task<IEnumerable<PersonDto>> GetAllAsync();

    Task<PersonDto?> GetByIdAsync(int id);

    Task<PersonDto> AddAsync(CreatePersonDto dto);

    Task<bool> UpdateAsync(UpdatePersonDto dto);

    Task<bool> DeleteAsync(int id);
}
