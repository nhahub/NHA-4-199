using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using HRManagementSystem.BLL.DTOs;

namespace HRManagementSystem.BLL.Validators;

public class UpdateCandidateValidator : AbstractValidator<UpdateCandidateDto>
{
    public UpdateCandidateValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.PersonId)
            .GreaterThan(0);

        RuleFor(x => x.ResumeLink)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.JobRequisition)
            .NotEmpty()
            .MaximumLength(200);
    }
}
