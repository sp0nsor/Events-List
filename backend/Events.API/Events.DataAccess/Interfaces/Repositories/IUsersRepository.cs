using Events.Core.Enums;
using Events.Core.Models;

namespace Events.DataAccess.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task Add(User user, CancellationToken cancellationToken = default);
        Task<User> GetByEmail(string email, CancellationToken cancellationToken = default);
        Task<HashSet<Permission>> GetUserPermissions(Guid userId, CancellationToken cancellationToken = default);
    }
}
