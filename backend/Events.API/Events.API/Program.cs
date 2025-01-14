using Events.API;
using Events.API.Middlewares;
using Events.Application;
using Events.DataAccess;
using Events.Infrastructure;
using Events.Infrastructure.Authentication;
using Serilog;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => 
    loggerConfig.ReadFrom.Configuration(context.Configuration));

var services = builder.Services;
var configuration = builder.Configuration;

services.AddAuthentication(configuration);

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
services.Configure<AuthorizationOptions>(configuration.GetSection(nameof(AuthorizationOptions)));

services
    .AddApi()
    .AddDataAccess(configuration)
    .AddInfrastructure()
    .AddApplication();

services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<RequestLogContextMiddleware>();
app.UseSerilogRequestLogging();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
