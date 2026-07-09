using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.BLL.BusinessRules.Interfaces;

public interface IDepartmentBusinessRules
{
    Task EnsureDepartmentNameIsUniqueAsync(string name);
}
