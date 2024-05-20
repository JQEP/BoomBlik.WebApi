using FluentValidation;
using BoomBlik.Core.Domain.Dtos;

namespace BoomBlik.Modules.Reports.Validators;

public class TreeValidator : AbstractValidator<TreeDto>
{
    public TreeValidator()
    {
        RuleFor(x => x.ProjectId)
            .NotEmpty().WithMessage("Project Id is required.");

        RuleFor(x => x.Location)
            .Length(0, 500).WithMessage("Location must be between 0 and 500 characters.");

        RuleFor(x => x.Longitude)
            .InclusiveBetween(-180, 180).WithMessage("Longitude must be between -180 and 180 degrees.");

        RuleFor(x => x.Latitude)
            .InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90 degrees.");
    }
}