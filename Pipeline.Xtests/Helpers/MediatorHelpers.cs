using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Mms.Pipelines;
using Pipeline.Xtests.Commands;

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

        services.Scan(scan => scan
            .FromAssembliesOf(typeof(AddUserCommand))
            .AddClasses()
            .AsImplementedInterfaces());

        services.AddLogging();

        var provider = services.BuildServiceProvider();

        return provider.GetRequiredService<IMediator>();
    }
}
