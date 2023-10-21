using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pipeline.Xtests.Commands;
using Pipelines;
using Pipelines.Behaviours;

namespace Pipeline.Xtests.Helpers;
public static class MediatorHelpers
{
    public static IMediator BuildMediator()
    {
        var services = new ServiceCollection();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(AddUserCommand).Assembly);
        });

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorisationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddTransient(typeof(ILogHandler<,>), typeof(AddUserCommandLogging<,>));
        services.AddTransient(typeof(IAuthorisationHandler<,>), typeof(AddUserCommandAuthorisation<,>));

        services.AddValidatorsFromAssembly(typeof(AddUserCommandValidator).Assembly);

        services.AddLogging();

        var provider = services.BuildServiceProvider();

        return provider.GetRequiredService<IMediator>();
    }
}
