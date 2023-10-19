using MediatR;
using Pipelines.Results;
using Pipelines.Results.Results;
using Pipelines.Tests.Dtos;

namespace Pipelines.Tests.Commands;
public class AddUserCommandHandler :IRequestHandler<AddUserCommand, IPipelineResult>
{
    public async Task<IPipelineResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        User user = new(request.FirstName, request.LastName);

        return await Task.FromResult(new SuccessResult(user));
    }
}
