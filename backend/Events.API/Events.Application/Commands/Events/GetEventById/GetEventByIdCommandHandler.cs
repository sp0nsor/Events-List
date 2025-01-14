using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Events.GetEventById
{
    public class GetEventByIdCommandHandler : IRequestHandler<GetEventByIdCommand, EventDto>
    {
        private readonly IEventsService eventsService;

        public GetEventByIdCommandHandler(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public async Task<EventDto> Handle(GetEventByIdCommand request, CancellationToken cancellationToken)
        {
            return await eventsService.GetEventByIdAsync(request.EventId);
        }
    }
}
