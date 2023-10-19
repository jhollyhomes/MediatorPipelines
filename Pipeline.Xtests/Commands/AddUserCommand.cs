using MediatR;
using Pipelines.Results;

namespace Pipeline.Xtests.Commands;

public class AddUserCommand : IRequest<IPipelineResult>
{
    public AddUserCommand(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public string FirstName { get; init; }
    public string LastName { get; init; }
}
