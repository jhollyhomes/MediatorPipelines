using MediatR;
using Pipelines;
using Pipelines.Results;

namespace Pipelines.Behaviours;
public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, IPipelineResult>
    where TRequest : IRequest<IPipelineResult>
{
    private readonly IEnumerable<ILogHandler<TRequest, IPipelineResult>> _logHandlers;

    public LoggingBehavior(IEnumerable<ILogHandler<TRequest, IPipelineResult>> logHandlers)
    {
        _logHandlers = logHandlers;
    }

    public async Task<IPipelineResult> Handle(TRequest request, RequestHandlerDelegate<IPipelineResult> next, CancellationToken cancellationToken)
    {
        var response = await next();

        foreach (var logHandler in _logHandlers)
        {
            await logHandler.Handle(request, response, cancellationToken);
        }

        return response;
    }
}
