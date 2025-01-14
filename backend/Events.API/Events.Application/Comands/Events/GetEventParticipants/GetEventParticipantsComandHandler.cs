using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Events.GetEventParticipants
{
    public class GetEventParticipantsComandHandler
        : IRequestHandler<GetEventParticipantsComand, List<ParticipantDto>>
    {
        private readonly IEventsService eventsService;

        public GetEventParticipantsComandHandler(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public async Task<List<ParticipantDto>> Handle(GetEventParticipantsComand request, CancellationToken cancellationToken)
        {
            return await eventsService.GetEventParticipantsAsync(request.EventId);
        }
    }
}
