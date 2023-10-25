using FluentValidation;
using Pipelines.Behaviours;

namespace Pipeline.Xtests.Commands;
public class AddUserCommandValidator : BaseValidationHandler<AddUserCommand>
{
    public AddUserCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
    }
}
