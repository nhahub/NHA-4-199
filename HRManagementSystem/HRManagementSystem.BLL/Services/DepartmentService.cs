using HRManagementSystem.BLL.BusinessRules;
using HRManagementSystem.BLL.BusinessRules.Interfaces;
using HRManagementSystem.BLL.DTOs;
using HRManagementSystem.BLL.Interfaces;
using HRManagementSystem.DAL.Entities;
using HRManagementSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.BLL.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDepartmentBusinessRules _departmentBusinessRules;
    
    public DepartmentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
    {
        var departments = await _unitOfWork.Departments.GetAllAsync();

        return departments.Select(d => new DepartmentDto
        {
            Id = d.Id,
            Name = d.Name,
            Description = d.Description,
            ManagerId = d.ManagerId,
            EmployeeCount = d.EmployeeCount
        });
    }

    public async Task<DepartmentDto?> GetByIdAsync(int id)
    {
        var department = await _unitOfWork.Departments.GetByIdAsync(id);

        if (department == null)
            return null;

        return new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            ManagerId = department.ManagerId,
            EmployeeCount = department.EmployeeCount
        };
    }


    public async Task<DepartmentDto> AddAsync(CreateDepartmentDto dto)
    {
        await _departmentBusinessRules
        .EnsureDepartmentNameIsUniqueAsync(dto.Name);
        var department = new Department
        {
            Name = dto.Name,
            Description = dto.Description,
            ManagerId = dto.ManagerId,
            EmployeeCount = 0
        };

        await _unitOfWork.Departments.AddAsync(department);

        await _unitOfWork.SaveChangesAsync();

        return new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            ManagerId = department.ManagerId,
            EmployeeCount = department.EmployeeCount
        };
    }


    public async Task<bool> UpdateAsync(UpdateDepartmentDto dto)
    {
        var department = await _unitOfWork.Departments.GetByIdAsync(dto.Id);

        if (department is null)
            return false;

        department.Name = dto.Name;
        department.Description = dto.Description;
        department.ManagerId = dto.ManagerId;

        _unitOfWork.Departments.Update(department);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var department = await _unitOfWork.Departments.GetByIdAsync(id);

        if (department is null)
            return false;

        _unitOfWork.Departments.Delete(department);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
