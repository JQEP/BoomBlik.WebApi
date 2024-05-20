using FluentValidation;
using BoomBlik.Core.Domain.Dtos;

namespace BoomBlik.Modules.Reports.Validators;

public class ProjectValidator : AbstractValidator<ProjectDto>
{
    public ProjectValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(1, 100).WithMessage("Name must be between 1 and 100 characters.");

        RuleFor(x => x.Location)
            .Length(0, 500).WithMessage("Location must be between 0 and 500 characters.");

        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("Customer Id is required.");
    }
}