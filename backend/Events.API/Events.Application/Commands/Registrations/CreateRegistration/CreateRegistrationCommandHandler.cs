using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Registrations.CreateRegistration
{
    public class CreateRegistrationCommandHandler
        : IRequestHandler<CreateRegistrationCommand>
    {
        private readonly IRegistrationsService registrationsService;

        public CreateRegistrationCommandHandler(
            IRegistrationsService registrationsService)
        {
            this.registrationsService = registrationsService;
        }

        public async Task Handle(CreateRegistrationCommand request, CancellationToken cancellationToken)
        {
            await registrationsService.CreateRegistrationAsync(request.EventId, request.ParticipantId);
        }
    }
}
