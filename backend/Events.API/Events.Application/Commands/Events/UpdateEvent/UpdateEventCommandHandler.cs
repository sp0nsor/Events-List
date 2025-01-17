using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Events.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Guid>
    {
        private readonly IEventsService eventsService;

        public UpdateEventCommandHandler(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }
        public async Task<Guid> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            return await eventsService.UpdateEventAync(
                request.Id,
                request.Name,
                request.Description,
                request.Place,
                request.Category,
                request.MaxParticipant,
                request.Date, 
                cancellationToken);
        }
    }
}
