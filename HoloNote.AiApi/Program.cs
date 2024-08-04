using Autofac;
using Autofac.Extensions.DependencyInjection;
using HoloNote.AiApi.Config;
using HoloNote.Core.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<GeminiApiConfig>(builder.Configuration.GetSection(nameof(GeminiApiConfig)), o => o.BindNonPublicProperties = true);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// Configure service provider to use autofac as dependency container
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(builder =>
{
    builder.RegisterModule(new MediatRModule());
    builder.RegisterModule(new AutoMapperModule());
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
