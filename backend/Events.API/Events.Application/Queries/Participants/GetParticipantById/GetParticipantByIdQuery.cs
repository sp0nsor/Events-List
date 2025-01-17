using Events.Application.DTOs;
using MediatR;

namespace Events.Application.Queries.Participants.GetParticipantById
{
    public record GetParticipantByIdQuery(
        Guid ParticipantId) : IRequest<ParticipantDto>;
}
