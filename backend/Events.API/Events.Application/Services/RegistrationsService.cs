using AutoMapper;
using Events.Application.Contracts.Registrations;
using Events.Application.Interfaces;
using Events.Core.Models;
using Events.DataAccess.Interfaces;

namespace Events.Application.Services
{
    public class RegistrationsService : IRegistrationsService
    {
        private readonly IMapper mapper;
        private readonly IRegistrationsRepository registrationsRepository;

        public RegistrationsService(
            IMapper mapper,
            IRegistrationsRepository registrationsRepository)
        {
            this.mapper = mapper;
            this.registrationsRepository = registrationsRepository;
        }

        public async Task CreateRegistration(CreateRegistrationRequest request)
        {
            var registration = Registration.Create(
                Guid.NewGuid(),
                request.EventId,
                request.ParticipantId);

            await registrationsRepository.Create(registration);
        }

        public async Task DeleteRegistration(Guid id)
        {
            await registrationsRepository.Delete(id);
        }
    }
}
