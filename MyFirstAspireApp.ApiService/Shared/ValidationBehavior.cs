// ------------------------------------------------------------------------------
//  <copyright file="ValidationBehavior.cs" company="MY-LEX b.v.">
//      Copyright (c) MY-LEX b.v., The Netherlands. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------

namespace MyFirstAspireApp.ApiService.Shared;

using FluentValidation;
using FluentValidation.Results;

using MediatR;

public sealed class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
    where TResponse : new()
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        ValidationResult[] validationFailures = await Task.WhenAll(
                                                    _validators.Select(validator => validator.ValidateAsync(context, cancellationToken))).ConfigureAwait(false);

        var errors = validationFailures
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .ToList();

        if (errors.Any())
        {
            throw new ValidationException("Request validation failed.", errors);
        }

        var response = await next();

        return response;
    }
}