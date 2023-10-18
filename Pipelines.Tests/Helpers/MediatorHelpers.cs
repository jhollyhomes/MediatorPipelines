using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Mms.Pipelines;

namespace Pipelines.Tests.Helpers;
public static class MediatorHelpers
{
    public static IMediator BuildMediator()
    {
        var services = new ServiceCollection();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(PipelineTests).Assembly);
        });

        services.AddLogging();

        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorisationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        var provider = services.BuildServiceProvider();

        return provider.GetRequiredService<IMediator>();
    }
}
