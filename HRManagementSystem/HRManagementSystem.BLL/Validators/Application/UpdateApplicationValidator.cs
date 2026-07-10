using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using HRManagementSystem.BLL.DTOs;

namespace HRManagementSystem.BLL.Validators;

public class UpdateApplicationValidator : AbstractValidator<UpdateApplicationDto>
{
    public UpdateApplicationValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.Status)
            .IsInEnum();

        RuleFor(x => x.Stage)
            .IsInEnum();
    }
}
