using FluentValidation;
using BoomBlik.Core.Domain.Dtos;

namespace BoomBlik.Modules.Reports.Validators;

public class TreeReportValidator : AbstractValidator<TreeReportDto>
{
    public TreeReportValidator()
    {
        RuleFor(x => x.TreeId)
            .NotEmpty().WithMessage("Tree ID is required.");

        RuleFor(x => x.Advice)
            .NotEmpty().WithMessage("Advice is required.");

        RuleFor(x => x.TreeHeight)
            .NotEmpty().WithMessage("Tree height is required.");

        RuleFor(x => x.Condition)
            .NotEmpty().WithMessage("Condition is required.");

        RuleFor(x => x.Groeifase)
            .NotEmpty().WithMessage("Growth phase is required.");

        RuleFor(x => x.Crown)
            .NotEmpty().WithMessage("Crown is required.");

        RuleFor(x => x.Stem)
            .NotEmpty().WithMessage("Stem is required.");

        RuleFor(x => x.StemFoot)
            .NotEmpty().WithMessage("Stem foot is required.");

        RuleFor(x => x.RiskClass)
            .NotEmpty().WithMessage("Risk class is required.");

        RuleFor(x => x.Orientation)
            .NotEmpty().WithMessage("Orientation is required.");

        RuleFor(x => x.FutureExpectation)
            .NotEmpty().WithMessage("Future expectation is required.");

        RuleFor(x => x.Urgency)
            .NotEmpty().WithMessage("Urgency is required.");

        RuleFor(x => x.Date)
            .NotEmpty().WithMessage("Date is required.");

        RuleFor(x => x.DateNextCheck)
            .NotEmpty().WithMessage("Date for next check is required.");
    }
}