using MediatR;

namespace Events.Application.Comands.Registrations.CreateRegistration
{
    public record CreateRegistrationCommand(
        Guid EventId,
        Guid ParticipantId) : IRequest<Guid>;
}
