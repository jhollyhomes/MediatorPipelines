﻿using FluentValidation;
using MediatR;

namespace Mms.Pipelines;
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) 
        => _validators = validators;

    public async Task<TResponse> Handle(TRequest request,
                                 RequestHandlerDelegate<TResponse> next,
                                 CancellationToken cancellationToken)
    {
        if (!_validators.Any()) 
        {
            return await next();
        }

        return await next();
    }
}
