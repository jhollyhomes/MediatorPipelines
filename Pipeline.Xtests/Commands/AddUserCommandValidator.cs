using FluentValidation;
using Pipeline.Xtests.Commands;

namespace Pipeline.Xtests.Commands;
public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    public AddUserCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
    }
}
