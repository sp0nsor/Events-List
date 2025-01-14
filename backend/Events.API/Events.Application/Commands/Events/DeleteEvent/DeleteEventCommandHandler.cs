using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Events.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IEventsService eventsService;

        public DeleteEventCommandHandler(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            await eventsService.DeleteEventAsync(request.EventId);
        }
    }
}
