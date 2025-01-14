using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Events.CreateEvent
{
    public class CreateEventComandHandler : IRequestHandler<CreateEventCommand>
    {
        private readonly IEventsService eventsService;

        public CreateEventComandHandler(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public async Task Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            await eventsService.CreateEventAsync(
                request.Name,
                request.Description,
                request.Place,
                request.Category,
                request.MaxParticipantCount,
                request.Date,
                request.Image);
        }
    }
}
