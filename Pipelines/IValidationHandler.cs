using MediatR;

namespace Pipelines;
public interface IValidationHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    Task<TResponse> Validate(TRequest request, CancellationToken cancellation);
}
