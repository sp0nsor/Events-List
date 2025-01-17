using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Queries.Events.GetEventById
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, EventDto>
    {
        private readonly IEventsService eventsService;

        public GetEventByIdQueryHandler(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public async Task<EventDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            return await eventsService.GetEventByIdAsync(request.EventId, cancellationToken);
        }
    }
}
