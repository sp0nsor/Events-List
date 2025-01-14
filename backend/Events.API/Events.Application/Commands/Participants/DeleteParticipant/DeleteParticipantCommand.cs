using MediatR;

namespace Events.Application.Comands.Participants.DeleteParticipant
{
    public record DeleteParticipantCommand(Guid ParticipantId) : IRequest;
}
