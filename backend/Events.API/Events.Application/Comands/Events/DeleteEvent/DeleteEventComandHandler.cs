using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Events.DeleteEvent
{
    public class DeleteEventComandHandler : IRequestHandler<DeleteEventComand>
    {
        private readonly IEventsService eventsService;

        public DeleteEventComandHandler(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public async Task Handle(DeleteEventComand request, CancellationToken cancellationToken)
        {
            await eventsService.DeleteEventAsync(request.EventId);
        }
    }
}
