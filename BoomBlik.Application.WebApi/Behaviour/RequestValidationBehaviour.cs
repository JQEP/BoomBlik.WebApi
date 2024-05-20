﻿using FluentValidation;
using MediatR;

namespace boomblik_api.Behaviour;

public sealed class RequestValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationFalures = await Task
            .WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var errors = validationFalures
            .Where(x => x.IsValid == false)
            .SelectMany(x => x.Errors)
            .ToList();

        if (errors.Count != 0)
        {
            throw new ValidationException("Validation failed", errors);
        }

        return await next();
    }
}