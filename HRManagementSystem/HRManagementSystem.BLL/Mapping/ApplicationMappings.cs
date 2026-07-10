using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.BLL.DTOs;
using HRManagementSystem.DAL.Entities;

namespace HRManagementSystem.BLL.Mappings;

public static class ApplicationMappings
{
    public static ApplicationDto ToDto(this Application application)
    {
        return new ApplicationDto
        {
            Id = application.Id,
            Date = application.Date,
            Status = application.Status,
            Stage = application.Stage,
            CandidateID = application.CandidateID,
            RequisitionID = application.RequisitionID,

            CandidateName = application.Candidate is not null
                ? $"{application.Candidate.Person?.FirstName} {application.Candidate.Person?.LastName}"
                : string.Empty,

            JobTitle = application.JobRequisition?.Title ?? string.Empty
        };
    }
}
