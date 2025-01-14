using Events.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;

namespace Events.Infrastructure.Authentication
{
    public class PermissionAuthorizationHandler
        : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IServiceScopeFactory scopeFactory;

        public PermissionAuthorizationHandler(
            IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PermissionRequirement requirement)
        {
            var userId = context.User.Claims.FirstOrDefault(
                x => x.Type == CustomClaims.UserId);

            if (userId is null || !Guid.TryParse(userId.Value, out var id))
                return;

            using var scope = scopeFactory.CreateScope();

            var permissionService = scope.ServiceProvider
                .GetRequiredService<IPermissionsService>();

            var permissions = await permissionService.GetPermissionsAsync(id);

            if (permissions.Intersect(requirement.Permissions).Any())
            {
                context.Succeed(requirement);
            }
        }
    }
}
