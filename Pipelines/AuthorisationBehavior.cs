using MediatR;
using Pipelines.Results;

namespace Mms.Pipelines;
public class AuthorisationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, IPipelineResult>
    where TRequest : IRequest<IPipelineResult>
    where TResponse : IPipelineResult
{
    public async Task<IPipelineResult> Handle(TRequest request, RequestHandlerDelegate<IPipelineResult> next, CancellationToken cancellationToken)
    {
        var response = await next();

        return response;
    }
}
