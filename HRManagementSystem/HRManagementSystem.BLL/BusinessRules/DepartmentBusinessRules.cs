using HRManagementSystem.BLL.BusinessRules.Interfaces;
using HRManagementSystem.BLL.Exceptions;
using HRManagementSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.BLL.BusinessRules;

public class DepartmentBusinessRules : IDepartmentBusinessRules
{
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentBusinessRules(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task EnsureDepartmentNameIsUniqueAsync(string name)
    {
        var existingDepartment = await _unitOfWork.Departments
            .FindAsync(d => d.Name == name);

        if (existingDepartment.Any())
        {
            throw new BusinessRuleException("Department name already exists.");
        }
    }
}


