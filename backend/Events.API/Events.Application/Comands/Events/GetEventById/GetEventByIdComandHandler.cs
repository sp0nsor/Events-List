using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Events.GetEventById
{
    public class GetEventByIdComandHandler : IRequestHandler<GetEventByIdComand, EventDto>
    {
        private readonly IEventsService eventsService;

        public GetEventByIdComandHandler(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public async Task<EventDto> Handle(GetEventByIdComand request, CancellationToken cancellationToken)
        {
            return await eventsService.GetEventByIdAsync(request.EventId);
        }
    }
}
