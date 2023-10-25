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

        services.Scan(scan => scan
                .FromApplicationDependencies()
                .AddClasses(x => x.AssignableTo(typeof(ILogHandler<,>))).AsImplementedInterfaces()
                .AddClasses(x => x.AssignableTo(typeof(IAuthorisationHandler<,>))).AsImplementedInterfaces()
                .AddClasses(x => x.AssignableTo(typeof(IValidationHandler<,>))).AsImplementedInterfaces()
                )
                .AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssembly(typeof(AddUserCommandHandler).Assembly);
                })
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorisationBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddLogging();

        var provider = services.BuildServiceProvider();

        return provider.GetRequiredService<IMediator>();
    }
}
