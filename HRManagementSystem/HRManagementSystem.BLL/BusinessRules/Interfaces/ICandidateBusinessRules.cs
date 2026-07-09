using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.BLL.DTOs;

namespace HRManagementSystem.BLL.BusinessRules.Interfaces;

public interface ICandidateBusinessRules
{
    Task ValidateCreateAsync(CreateCandidateDto dto);

    Task ValidateUpdateAsync(UpdateCandidateDto dto);
}
