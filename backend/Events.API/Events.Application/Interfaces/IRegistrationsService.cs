using Events.Application.Contracts.Registrations;
using Events.Core.Models;

namespace Events.Application.Interfaces
{
    public interface IRegistrationsService
    {
        Task CreateRegistration(CreateRegistrationRequest request);
        Task DeleteRegistration(Guid id);
    }
}