using MediatR;
using Microsoft.Extensions.Logging;
using Pipelines.Results;

namespace Mms.Pipelines;
public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, IPipelineResult>
    where TRequest : IRequest<IPipelineResult>
    where TResponse : IPipelineResult
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<IPipelineResult> Handle(TRequest request, RequestHandlerDelegate<IPipelineResult> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Handling {typeof(TRequest).Name}");

        var response = await next();
        
        _logger.LogInformation($"Handled {typeof(TResponse).Name}");

        return response;
    }
}
