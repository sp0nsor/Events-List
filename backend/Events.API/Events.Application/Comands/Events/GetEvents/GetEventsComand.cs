using Events.Application.DTOs;
using MediatR;

namespace Events.Application.Comands.Events.GetEvents
{
    public record GetEventsComand(
        string? SearchName,
        string? SearchPlace,
        string? SearchCategory,
        string? SortItem,
        string? SortOrder,
        int Page = 1,
        int PageSize = 10) : IRequest<EventsPageDto>;
}
