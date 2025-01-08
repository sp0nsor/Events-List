using Events.Core.Models;

namespace Events.Application.Interfaces
{
    public interface IRegistrationsService
    {
        Task CreateRegistration(Registration registration);
        Task DeleteRegistration(Guid id);
    }
}