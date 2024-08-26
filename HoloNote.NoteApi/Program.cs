using Autofac;
using Autofac.Extensions.DependencyInjection;

using HoloNote.Core.Modules;
using HoloNote.DbConnection.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("LocalDb");
var dbConnectionConfig = new DbConnectionConfig
{
    Local = connectionString ?? string.Empty
};

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(builder =>
{
    builder.RegisterModule(new DbModule(dbConnectionConfig));
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
