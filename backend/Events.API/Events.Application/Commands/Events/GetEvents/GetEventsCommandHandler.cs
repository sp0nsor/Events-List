using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Events.GetEvents
{
    public class GetEventsCommandHandler : IRequestHandler<GetEventsCommand, EventsPageDto>
    {
        private readonly IEventsService eventsService;

        public GetEventsCommandHandler(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public async Task<EventsPageDto> Handle(GetEventsCommand request, CancellationToken cancellationToken)
        {
            return await eventsService.GetEventsAsync(
                request.SearchName,
                request.SearchPlace,
                request.SearchCategory,
                request.SortItem,
                request.SortOrder,
                request.Page,
                request.PageSize);
        }
    }
}
