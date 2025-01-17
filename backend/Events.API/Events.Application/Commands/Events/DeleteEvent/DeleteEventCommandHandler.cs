using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Commands.Events.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, Guid>
    {
        private readonly IEventsService eventsService;

        public DeleteEventCommandHandler(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public async Task<Guid> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            return await eventsService.DeleteEventAsync(request.EventId, cancellationToken);
        }
    }
}
