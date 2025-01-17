using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Queries.Events.GetEvents
{
    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, EventsPageDto>
    {
        private readonly IEventsService eventsService;

        public GetEventsQueryHandler(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public async Task<EventsPageDto> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            return await eventsService.GetEventsAsync(
                request.SearchName,
                request.SearchPlace,
                request.SearchCategory,
                request.SortItem,
                request.SortOrder,
                cancellationToken,
                request.Page,
                request.PageSize);
        }
    }
}
