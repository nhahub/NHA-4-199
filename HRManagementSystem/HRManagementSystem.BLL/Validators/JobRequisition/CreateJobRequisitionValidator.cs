using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using HRManagementSystem.BLL.DTOs;

namespace HRManagementSystem.BLL.Validators;

public class CreateJobRequisitionValidator : AbstractValidator<CreateJobRequisitionDto>
{
    public CreateJobRequisitionValidator()
    {
        RuleFor(x => x.EmployeeID)
            .GreaterThan(0);

        RuleFor(x => x.DepartmentID)
            .GreaterThan(0);

        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.Headcount)
            .GreaterThan(0);

        RuleFor(x => x.Status)
            .IsInEnum();
    }
}
