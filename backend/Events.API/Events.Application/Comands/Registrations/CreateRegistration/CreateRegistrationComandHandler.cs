using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Registrations.CreateRegistration
{
    public class CreateRegistrationComandHandler
        : IRequestHandler<CreateRegistrationComand>
    {
        private readonly IRegistrationsService registrationsService;

        public CreateRegistrationComandHandler(
            IRegistrationsService registrationsService)
        {
            this.registrationsService = registrationsService;
        }

        public async Task Handle(CreateRegistrationComand request, CancellationToken cancellationToken)
        {
            await registrationsService.CreateRegistrationAsync(request.EventId, request.ParticipantId);
        }
    }
}
