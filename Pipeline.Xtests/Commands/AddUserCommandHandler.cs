using MediatR;
using Pipeline.Xtests.Dtos;
using Pipelines.Results;

namespace Pipeline.Xtests.Commands;
public class AddUserCommandHandler :IRequestHandler<AddUserCommand, IPipelineResult>
{
    public async Task<IPipelineResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        User user = new(request.FirstName, request.LastName);

        return await Task.FromResult(new SuccessResult(user));
    }
}
