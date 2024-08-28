using Autofac;

using HoloNote.DbConnection;
using HoloNote.DbConnection.Configuration;

using Microsoft.EntityFrameworkCore;

namespace HoloNote.Core.Modules;

public class DbModule : Autofac.Module
{
    private readonly DbConnectionConfig _dbConnectionConfig;

    public DbModule(DbConnectionConfig dbConnectionConfig)
    {
        _dbConnectionConfig = dbConnectionConfig;
    }
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.Register(x =>
        {
            var optionsBuilder = new DbContextOptionsBuilder<HoloNoteDbContext>();
            optionsBuilder.UseSqlServer(_dbConnectionConfig.Local, x => x.MigrationsAssembly("HoloNote.DbConnection"));
            return new HoloNoteDbContext(optionsBuilder.Options);
        }).InstancePerLifetimeScope();
    }
}
