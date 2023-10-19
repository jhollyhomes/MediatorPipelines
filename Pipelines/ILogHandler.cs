using MediatR;

namespace Pipelines;
public interface ILogHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request, TResponse response, CancellationToken cancellationToken);
}
