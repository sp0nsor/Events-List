using AutoMapper;
using Events.Application.Contracts.Registrations;
using Events.Application.Interfaces;
using Events.Core.Models;
using Events.DataAccess.Interfaces;

namespace Events.Application.Services
{
    public class RegistrationsService : IRegistrationsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public RegistrationsService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task CreateRegistration(CreateRegistrationRequest request)
        {
            var registration = Registration.Create(
                Guid.NewGuid(),
                request.EventId,
                request.ParticipantId);

            await unitOfWork.Registrations.Create(registration);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteRegistration(Guid id)
        {
            await unitOfWork.Registrations.Delete(id);
        }
    }
}
