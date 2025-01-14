using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Events.UpdateEvent
{
    public class UpdateEventComandHandler : IRequestHandler<UpdateEventComand>
    {
        private readonly IEventsService eventsService;

        public UpdateEventComandHandler(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }
        public async Task Handle(UpdateEventComand request, CancellationToken cancellationToken)
        {
            await eventsService.UpdateEventAync(
                request.Id,
                request.Name,
                request.Description,
                request.Place,
                request.Category,
                request.MaxParticipant,
                request.Date);
        }
    }
}
