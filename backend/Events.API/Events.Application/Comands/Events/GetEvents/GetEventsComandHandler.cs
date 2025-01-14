using Events.Application.DTOs;
using Events.Application.Interfaces.Services;
using MediatR;

namespace Events.Application.Comands.Events.GetEvents
{
    public class GetEventsComandHandler : IRequestHandler<GetEventsComand, EventsPageDto>
    {
        private readonly IEventsService eventsService;

        public GetEventsComandHandler(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public async Task<EventsPageDto> Handle(GetEventsComand request, CancellationToken cancellationToken)
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
