using Events.Application.DTOs;
using MediatR;

namespace Events.Application.Queries.Events.GetEvents
{
    public record GetEventsQuery(
        string? SearchName,
        string? SearchPlace,
        string? SearchCategory,
        string? SortItem,
        string? SortOrder,
        int Page = 1,
        int PageSize = 10) : IRequest<EventsPageDto>;
}
