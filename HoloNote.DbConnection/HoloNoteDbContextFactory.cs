using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HoloNote.DbConnection;

//Added to allow create migrations from this project - Configure all neccessery options to build DbContext
public class HoloNoteDbContextFactory : IDesignTimeDbContextFactory<HoloNoteDbContext>
{
    public HoloNoteDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<HoloNoteDbContext>();
        var connectionString = configuration.GetConnectionString("LocalDb");

        builder.UseSqlServer(connectionString);
        return new HoloNoteDbContext(builder.Options);
    }
}
