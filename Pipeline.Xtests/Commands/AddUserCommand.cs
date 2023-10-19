using MediatR;
using Pipelines.Results;

namespace Pipeline.Xtests.Commands;

public class AddUserCommand : IRequest<IPipelineResult>
{
    public AddUserCommand(string firstName, string lastName, string userName)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
    }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string UserName { get; }
}
