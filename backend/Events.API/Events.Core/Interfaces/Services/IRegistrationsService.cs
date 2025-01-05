using Events.Core.Models;

namespace Events.Application.Services
{
    public interface IRegistrationsService
    {
        Task CreateRegistration(Registration registration);
        Task DeleteRegistration(Guid id);
    }
}