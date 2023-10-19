using Microsoft.Extensions.Logging;
using Pipelines;
using Pipelines.Results;
using Pipelines.Results.Results;

namespace Pipeline.Xtests.Commands;
public class AddUserCommandLogging : ILogHandler<AddUserCommand, IPipelineResult>
{
    private readonly ILogger<AddUserCommandLogging> _logger;

    public AddUserCommandLogging(ILogger<AddUserCommandLogging> logger)
    {
        _logger = logger;
    }

    public async Task<IPipelineResult> Handle(AddUserCommand request, IPipelineResult response, CancellationToken cancellationToken)
    {
        var message = $"Add User Command - Firstname : {request.FirstName} Lastname : {request.LastName}";
    
         _logger.LogInformation(message);

        return await Task.FromResult(response);
    }
}
