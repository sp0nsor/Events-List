using Events.Core.Enums;

namespace Events.Application.Interfaces.Services
{
    public interface IPermissionService
    {
        Task<HashSet<Permission>> GetPermissionsAsync(Guid userId);
    }
}