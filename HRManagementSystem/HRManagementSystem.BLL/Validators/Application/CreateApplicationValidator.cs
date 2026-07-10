using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using HRManagementSystem.BLL.DTOs;

namespace HRManagementSystem.BLL.Validators;

public class CreateApplicationValidator : AbstractValidator<CreateApplicationDto>
{
    public CreateApplicationValidator()
    {
        RuleFor(x => x.CandidateID)
            .GreaterThan(0);

        RuleFor(x => x.RequisitionID)
            .GreaterThan(0);
    }
}
