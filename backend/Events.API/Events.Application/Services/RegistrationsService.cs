using Events.Core.Models;
using Events.DataAccess.Repositories;

namespace Events.Application.Services
{
    public class RegistrationsService : IRegistrationsService
    {
        private readonly IRegistrationsRepository registrationsRepository;

        public RegistrationsService(IRegistrationsRepository registrationsRepository)
        {
            this.registrationsRepository = registrationsRepository;
        }

        public async Task CreateRegistration(Registration registration)
        {
            await registrationsRepository.Create(registration);
        }

        public async Task DeleteRegistration(Guid id)
        {
            await registrationsRepository.Delete(id);
        }
    }
}
