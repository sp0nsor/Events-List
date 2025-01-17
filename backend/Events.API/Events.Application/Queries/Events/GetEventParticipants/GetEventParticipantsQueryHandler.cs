using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Queries.Events.GetEventParticipants
{
    public class GetEventParticipantsQueryHandler
        : IRequestHandler<GetEventParticipantsQuery, List<ParticipantDto>>
    {
        private readonly IEventsService eventsService;

        public GetEventParticipantsQueryHandler(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public async Task<List<ParticipantDto>> Handle(GetEventParticipantsQuery request, CancellationToken cancellationToken)
        {
            return await eventsService.GetEventParticipantsAsync(request.EventId, cancellationToken);
        }
    }
}
