using Events.Application.Contracts.Registrations;
using Events.Application.Interfaces.UseCases.Registrations;
using Events.Core.Models;
using Events.DataAccess.Interfaces.Repositories;

namespace Events.Application.UseCases.Registrations
{
    public class CreateRegistrationUseCase : ICreateRegistrationUseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateRegistrationUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Execute(CreateRegistrationRequest request)
        {
            var registration = Registration.Create(
                Guid.NewGuid(),
                request.EventId,
                request.ParticipantId);

            await unitOfWork.Registrations.Create(registration);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
