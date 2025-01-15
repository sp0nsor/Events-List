using Events.Core.Models;

namespace Events.DataAccess.Interfaces.Repositories
{
    public interface IRegistrationsRepository
    {
        Task<Guid> Create(Registration registration);
        Task<Guid> Delete(Guid id);
    }
}