using MediatR;

namespace Events.Application.Comands.Participants.DeleteParticipant
{
    public record DeleteParticipantComand(Guid ParticipantId) : IRequest;
}
