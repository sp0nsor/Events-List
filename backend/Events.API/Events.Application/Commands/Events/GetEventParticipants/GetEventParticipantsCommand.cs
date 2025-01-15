using Events.Application.DTOs;
using MediatR;

namespace Events.Application.Comands.Events.GetEventParticipants
{
    public record GetEventParticipantsCommand(
        Guid EventId) : IRequest<List<ParticipantDto>>;
}
