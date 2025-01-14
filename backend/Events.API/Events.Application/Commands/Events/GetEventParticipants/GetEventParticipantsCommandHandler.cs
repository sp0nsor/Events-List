using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Events.GetEventParticipants
{
    public class GetEventParticipantsCommandHandler
        : IRequestHandler<GetEventParticipantsCommand, List<ParticipantDto>>
    {
        private readonly IEventsService eventsService;

        public GetEventParticipantsCommandHandler(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public async Task<List<ParticipantDto>> Handle(GetEventParticipantsCommand request, CancellationToken cancellationToken)
        {
            return await eventsService.GetEventParticipantsAsync(request.EventId);
        }
    }
}
