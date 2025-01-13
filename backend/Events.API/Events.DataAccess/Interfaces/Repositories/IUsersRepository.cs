using Events.Core.Enums;
using Events.Core.Models;

namespace Events.DataAccess.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task Add(User user);
        Task<User> GetByEmail(string email);
        Task<HashSet<Permission>> GetUserPermissions(Guid userId);
    }
}