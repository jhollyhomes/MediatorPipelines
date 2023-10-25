using FluentValidation;
using MediatR;
using Pipelines.Results;

namespace Pipelines.Behaviours;
public abstract class BaseValidationHandler<TRequest> : AbstractValidator<TRequest>, IValidationHandler<TRequest, IPipelineResult>
    where TRequest : IRequest<IPipelineResult>
{
    public virtual async Task<IPipelineResult> Validate(TRequest request, CancellationToken cancellationToken)
    {
        var validationResults = this.Validate(request);

        if (validationResults.IsValid)
        {
            return await Task.FromResult(new SuccessResult());
        }

        var errors = validationResults.Errors
                                      .Select(x => x.ErrorMessage)
        .ToList();

        return await Task.FromResult(new ValidationFailureResult(errors));
    }
}
