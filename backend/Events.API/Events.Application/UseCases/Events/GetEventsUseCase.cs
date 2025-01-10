using AutoMapper;
using Events.Application.Contracts.Events;
using Events.Application.Interfaces.UseCases.Events;
using Events.DataAccess.Interfaces;

namespace Events.Application.UseCases.Events
{
    public class GetEventsUseCase : IGetEventsUseCase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetEventsUseCase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<EventsPageResponse> Execute(GetEventRequest request)
        {
            var eventsPage = await unitOfWork.Events.Get(
                request.SearchName,
                request.SearchPlace,
                request.SearchCategory,
                request.SortItem,
                request.SortOrder,
                request.Page,
                request.PageSize);

            return mapper.Map<EventsPageResponse>(eventsPage);
        }
    }
}
