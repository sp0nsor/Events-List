using Events.Application.DTOs;
using MediatR;

namespace Events.Application.Comands.Participants.GetParticipantById
{
    public record GetParticipantByIdCommand(Guid ParticipantId) : IRequest<ParticipantDto>;
}
