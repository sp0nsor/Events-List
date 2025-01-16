using Events.API.Infrastructure;
using Events.Core.Enums;
using Events.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Events.API
{
    public static class ApiExtansions
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            var assemblies = new[]
            {
                Assembly.Load("Events.Application")
            };

            services.AddMediatR(x =>
                x.RegisterServicesFromAssemblies(assemblies));

            services.AddExceptionHandler<GlobalExceptionHandler>();

            return services;
        }

        public static void AddAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection
                (nameof(JwtOptions)).Get<JwtOptions>();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtOptions!.SecretKey))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["tasty-cookies"];

                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy =>
                {
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);

                    policy.Requirements.Add(new PermissionRequirement([Permission.Create]));
                    policy.Requirements.Add(new PermissionRequirement([Permission.Update]));
                    policy.Requirements.Add(new PermissionRequirement([Permission.Delete]));
                });

                options.AddPolicy("UserPolicy", policy =>
                {
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);

                    policy.Requirements.Add(new PermissionRequirement([Permission.Read]));
                });
            });
        }
        public static IEndpointConventionBuilder RequirePermissions<TBuilder>(
            this TBuilder builder, params Permission[] permissions)
                where TBuilder : IEndpointConventionBuilder
        {
            return builder
                .RequireAuthorization(pb =>
                    pb.AddRequirements(new PermissionRequirement(permissions)));
        }
    }
}
