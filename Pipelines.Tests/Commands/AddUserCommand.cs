using MediatR;
using Pipelines.Tests.Dtos;

namespace Pipelines.Tests.Commands;

public class AddUserCommand : IRequest<User>
{
    public AddUserCommand(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public string FirstName { get; init; }
    public string LastName { get; init; }
}
