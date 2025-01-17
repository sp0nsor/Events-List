using Events.Application.DTOs;
using MediatR;

namespace Events.Application.Queries.Events.GetEventParticipants
{
    public record GetEventParticipantsQuery(
        Guid EventId) : IRequest<List<ParticipantDto>>;
}
