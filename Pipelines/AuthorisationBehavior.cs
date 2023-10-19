using MediatR;
using Pipelines;
using Pipelines.Results;

namespace Mms.Pipelines;
public class AuthorisationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, IPipelineResult>
    where TRequest : IRequest<IPipelineResult>
    where TResponse : IPipelineResult
{
    private readonly IEnumerable<IAuthorisationHandler<TRequest, IPipelineResult>> _authorisationHandlers;

    public AuthorisationBehavior(IEnumerable<IAuthorisationHandler<TRequest, IPipelineResult>> authorisationHandlers)
    {
        _authorisationHandlers = authorisationHandlers;
    }

    public async Task<IPipelineResult> Handle(TRequest request, RequestHandlerDelegate<IPipelineResult> next, CancellationToken cancellationToken)
    {
        foreach (var authHandler in _authorisationHandlers)
        {
            var authResult = await authHandler.Handle(request, cancellationToken);

            if (!authResult.IsSuccess)
            {
                return authResult;
            }
        }

        return await next();
    } 
}
