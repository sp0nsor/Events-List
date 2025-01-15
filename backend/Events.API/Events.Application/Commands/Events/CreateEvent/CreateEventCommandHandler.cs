using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Events.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventsService eventsService;

        public CreateEventCommandHandler(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            return await eventsService.CreateEventAsync(
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
