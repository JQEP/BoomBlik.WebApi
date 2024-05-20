using FluentValidation;
using BoomBlik.Core.Domain.Dtos;

namespace BoomBlik.Modules.Reports.Validators
{
    public class TreeReportPictureValidator : AbstractValidator<TreeReportPictureDto>
    {
        public TreeReportPictureValidator()
        {
            RuleFor(x => x.TreeReportId)
                .NotEmpty().WithMessage("TreeReportId is required.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("ImageUrl is required.")
                .Length(1, 500).WithMessage("ImageUrl must be between 1 and 500 characters.");
        }
    }
}