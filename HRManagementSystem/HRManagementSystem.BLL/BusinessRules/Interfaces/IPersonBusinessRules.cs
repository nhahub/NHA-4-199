using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.BLL.DTOs;

namespace HRManagementSystem.BLL.BusinessRules.Interfaces;

public interface IPersonBusinessRules
{
    Task ValidateCreateAsync(CreatePersonDto dto);

    Task ValidateUpdateAsync(UpdatePersonDto dto);
}
