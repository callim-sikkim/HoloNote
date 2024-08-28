using Autofac;

using HoloNote.Core.AutoMapper;

namespace HoloNote.Core.Modules;

public class AutoMapperModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.RegisterInstance(AutoMapperConfig.Init()).SingleInstance();
    }
}
