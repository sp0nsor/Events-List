using Events.Application.Interfaces.Services;
using Events.Core.Enums;
using Events.DataAccess.Interfaces.Repositories;

namespace Events.Application.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork unitOfWork;

        public PermissionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<HashSet<Permission>> GetPermissionsAsync(Guid userId)
        {
            return unitOfWork.Users.GetUserPermissions(userId);
        }
    }
}
