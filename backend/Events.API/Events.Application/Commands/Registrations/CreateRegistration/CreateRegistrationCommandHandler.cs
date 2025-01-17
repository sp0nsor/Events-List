using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Registrations.CreateRegistration
{
    public class CreateRegistrationCommandHandler
        : IRequestHandler<CreateRegistrationCommand, Guid>
    {
        private readonly IRegistrationsService registrationsService;

        public CreateRegistrationCommandHandler(
            IRegistrationsService registrationsService)
        {
            this.registrationsService = registrationsService;
        }

        public async Task<Guid> Handle(CreateRegistrationCommand request, CancellationToken cancellationToken)
        {
            return await registrationsService.CreateRegistrationAsync(
                request.EventId,
                request.ParticipantId,
                cancellationToken);
        }
    }
}
