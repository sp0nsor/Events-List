using Events.Application.DTOs;
using MediatR;

namespace Events.Application.Comands.Participants.GetParticipants
{
    public record GetParticipantsComand(
        int Page = 1,
        int PageSize = 10) : IRequest<List<ParticipantDto>>;
}
