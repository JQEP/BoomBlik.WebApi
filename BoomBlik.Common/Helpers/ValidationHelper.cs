using FluentValidation;

namespace SmartOffice.Common.Helpers;

public static class ValidationHelper
{
    private const int MinPageSize = 5;
    private const int MaxPageSize = 50;

    public static void ValidateAndThrowArgumentException<T>(this T obj, IValidator<T> validator)
    {
        var validationResult = validator.Validate(obj);
        if (!validationResult.IsValid)
        {
            throw new ArgumentException(string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage)));
        }
    }
}