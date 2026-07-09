using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using HRManagementSystem.BLL.DTOs;

namespace HRManagementSystem.BLL.Validators;

public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentDto>
{
    public UpdateDepartmentValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Department name is required.")
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500);

        RuleFor(x => x.ManagerId)
            .GreaterThan(0)
            .WithMessage("Manager is required.");
    }
}
