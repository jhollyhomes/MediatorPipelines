using MediatR;
using Pipelines.Tests.Dtos;

namespace Pipelines.Tests.Commands;
public class AddUserCommandHandler :IRequestHandler<AddUserCommand, User>
{

    public Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {



        var user = new User(request.FirstName, request.LastName);

        return Task.FromResult(user);
    }
}
