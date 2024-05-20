using FluentValidation;
using BoomBlik.Core.Domain.Dtos;

namespace BoomBlik.Modules.Reports.Validators
{
    public class CustomerAddressValidator : AbstractValidator<CustomerAddressDto>
    {
        public CustomerAddressValidator()
        {
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street name is required.")
                .Length(1, 100).WithMessage("Street name must be between 1 and 100 characters.");

            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Street number is required.");

            RuleFor(x => x.Zipcode)
                .NotEmpty().WithMessage("Zipcode is required.")
                .Length(5, 10).WithMessage("Zipcode must be between 5 and 10 characters.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.")
                .Length(1, 100).WithMessage("City must be between 1 and 100 characters.");
        }
    }
}