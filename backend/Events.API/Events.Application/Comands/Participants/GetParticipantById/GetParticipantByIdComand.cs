using Events.Application.DTOs;
using MediatR;

namespace Events.Application.Comands.Participants.GetParticipantById
{
    public record GetParticipantByIdComand(Guid ParticipantId) : IRequest<ParticipantDto>;
}
