using Events.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Events.Infrastructure.Authentication
{
    public class PermissionRequirement 
        : IAuthorizationRequirement
    {
        public PermissionRequirement(Permission[] permissions)
        {
            Permissions = permissions;
        }

        public Permission[] Permissions { get; set; }
    }
}
