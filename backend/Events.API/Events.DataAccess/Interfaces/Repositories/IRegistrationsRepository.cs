using Events.Core.Models;

namespace Events.DataAccess.Interfaces.Repositories
{
    public interface IRegistrationsRepository
    {
        Task Create(Registration registration);
        Task Delete(Guid id);
    }
}