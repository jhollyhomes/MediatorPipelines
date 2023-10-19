using FluentValidation;
using MediatR;
using Pipelines.Results;
using Pipelines.Results.Results;

namespace Mms.Pipelines;
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, IPipelineResult>
    where TRequest : IRequest<IPipelineResult>
    where TResponse : IPipelineResult
{ 
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) 
        => _validators = validators;

    public async Task<IPipelineResult> Handle(TRequest request,
                                 RequestHandlerDelegate<IPipelineResult> next,
                                 CancellationToken cancellationToken)
    {
        if (_validators.Any()) 
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            var messages = failures.Select(x => x.ErrorMessage).ToList();

            if (failures.Count != 0)
            {
                return new ValidtionFailureResult(messages);
            }
        }

        return await next();
    }
}
