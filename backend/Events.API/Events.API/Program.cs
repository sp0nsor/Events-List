using Events.API;
using Events.API.Infrastructure;
using Events.API.Middlewares;
using Events.Application;
using Events.DataAccess;
using Events.DataAccess.Mappings;
using Serilog;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => 
    loggerConfig.ReadFrom.Configuration(context.Configuration));

var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.Configure<AuthorizationOptions>(configuration.GetSection(nameof(AuthorizationOptions)));

var assemblies = new[]
{
    Assembly.Load("Events.Application")
};

services.AddMediatR(x =>
    x.RegisterServicesFromAssemblies(assemblies));

services
    .AddApi()
    .AddDataAccess(configuration)
    .AddApplication();

services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

app.UseMiddleware<RequestLogContextMiddleware>();
app.UseSerilogRequestLogging();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
