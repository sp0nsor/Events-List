using Events.Core.Enums;

namespace Events.Application.Interfaces.Services
{
    public interface IPermissionsService
    {
        Task<HashSet<Permission>> GetPermissionsAsync(Guid userId);
    }
}