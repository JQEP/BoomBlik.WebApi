using FluentValidation;
using BoomBlik.Core.Domain.Dtos;

namespace BoomBlik.Modules.Reports.Validators
{
    public class TreeReportPdfValidator : AbstractValidator<TreeReportPdfDto>
    {
        public TreeReportPdfValidator()
        {
            RuleFor(x => x.TreeReportId)
                .NotEmpty().WithMessage("TreeReportId is required.");

            RuleFor(x => x.PdfUrl)
                .NotEmpty().WithMessage("PdfUrl is required.")
                .Length(1, 500).WithMessage("PdfUrl must be between 1 and 500 characters.");
        }
    }
}