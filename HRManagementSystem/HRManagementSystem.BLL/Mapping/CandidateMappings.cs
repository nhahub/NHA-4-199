using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.BLL.DTOs;
using HRManagementSystem.DAL.Entities;

namespace HRManagementSystem.BLL.Mappings;

public static class CandidateMappings
{
    public static CandidateDto ToDto(this Candidate candidate)
    {
        return new CandidateDto
        {
            Id = candidate.Id,
            PersonId = candidate.PersonId,
            PersonName = $"{candidate.Person!.FirstName} {candidate.Person.LastName}",
            ResumeLink = candidate.ResumeLink,
            JobRequisition = candidate.JobRequisition
        };
    }

    public static Candidate ToEntity(this CreateCandidateDto dto)
    {
        return new Candidate
        {
            PersonId = dto.PersonId,
            ResumeLink = dto.ResumeLink,
            JobRequisition = dto.JobRequisition
        };
    }
}
