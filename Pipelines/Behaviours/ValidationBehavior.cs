using MediatR;
using Pipelines.Results;

namespace Pipelines.Behaviours;
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, IPipelineResult>
    where TRequest : IRequest<TResponse>
    where TResponse : IPipelineResult
{
    private readonly IEnumerable<IValidationHandler<TRequest, TResponse>> _validators;

    public ValidationBehavior(IEnumerable<IValidationHandler<TRequest, TResponse>> validators)
    {
        _validators = validators;
    }

    public async Task<IPipelineResult> Handle(TRequest request,
                                 RequestHandlerDelegate<IPipelineResult> next,
                                 CancellationToken cancellationToken)
    {
        foreach (var validator in _validators)
        {
            var validationResult = await validator.Validate(request, cancellationToken);

            if (!validationResult.IsSuccess) return validationResult;
        }

        return await next();
    }
}