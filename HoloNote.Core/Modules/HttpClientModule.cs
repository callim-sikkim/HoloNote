using Autofac;
using HoloNote.Core.Config;
using HoloNote.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HoloNote.Core.Modules;

public class HttpClientModule : Module
{
    private readonly AiConnectionConfig _aiConfig;

    public HttpClientModule(AiConnectionConfig aiConfig)
    {
        _aiConfig = aiConfig;
    }

    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.Register(ctx =>
        {
            var service = new ServiceCollection();
            service.AddHttpClient();

            var serviceProvider = service.BuildServiceProvider();
            return serviceProvider.GetRequiredService<IHttpClientFactory>();
        })
            .As<IHttpClientFactory>()
            .SingleInstance();
        builder.RegisterInstance(_aiConfig).As<AiConnectionConfig>().SingleInstance();
        builder.RegisterType<AiService>().As<IAIService>();
    }
}
