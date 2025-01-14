using MediatR;

namespace Events.Application.Comands.Registrations.CreateRegistration
{
    public record CreateRegistrationComand(
        Guid EventId,
        Guid ParticipantId) : IRequest;
}
