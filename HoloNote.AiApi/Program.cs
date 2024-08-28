using Autofac;
using Autofac.Extensions.DependencyInjection;

using HoloNote.Core.Config;
using HoloNote.Core.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var aiSection = builder.Configuration.GetSection(nameof(AiConnectionConfig));
var config = new AiConnectionConfig
{
    ApiKey = aiSection["ApiKey"] ?? string.Empty,
    LifeTimeSpan = double.Parse(aiSection["LifeTimeSpan"] ?? string.Empty),
    Url = aiSection["url"] ?? string.Empty,
};

/// Configure service provider to use autofac as dependency container
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(builder =>
{
    builder.RegisterModule(new MediatRModule());
    builder.RegisterModule(new AutoMapperModule());
    builder.RegisterModule(new HttpClientModule(config));
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
