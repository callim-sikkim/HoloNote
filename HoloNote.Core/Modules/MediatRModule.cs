using Autofac;
using MediatR;
using MediatR.Pipeline;
using System.Reflection;

namespace HoloNote.Core.Modules;

/// <summary>
/// Autofac module implementing MediatR configuration
/// </summary>
public class MediatRModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.RegisterType<Mediator>().As<IMediator>().SingleInstance();
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

        var mediatrOpenTypes = new[]
        {
            typeof(IRequestHandler<,>),
            typeof(IRequestExceptionHandler<,,>),
            typeof(IRequestExceptionAction<,>),
            typeof(INotificationHandler<>),
            typeof(IStreamRequestHandler<,>),
        };

        foreach (var mediatrOptionType in mediatrOpenTypes)
        {
            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(mediatrOptionType)
                .InstancePerDependency();
        }
    }
}
