using Events.Application.Authentication;
using Events.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.SqlServer.Update.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
