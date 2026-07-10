using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.BLL.DTOs;
using HRManagementSystem.DAL.Entities;

namespace HRManagementSystem.BLL.Mappings;

public static class JobRequisitionMappings
{
    public static JobRequisitionDto ToDto(this JobRequisition job)
    {
        return new JobRequisitionDto
        {
            Id = job.Id,
            EmployeeID = job.EmployeeID,
            Title = job.Title,
            Description = job.Description,
            Headcount = job.Headcount,
            Status = job.Status,
            DepartmentID = job.DepartmentID
        };
    }

    public static JobRequisition ToEntity(this CreateJobRequisitionDto dto)
    {
        return new JobRequisition
        {
            EmployeeID = dto.EmployeeID,
            Title = dto.Title,
            Description = dto.Description,
            Headcount = dto.Headcount,
            Status = dto.Status,
            DepartmentID = dto.DepartmentID
        };
    }
}
