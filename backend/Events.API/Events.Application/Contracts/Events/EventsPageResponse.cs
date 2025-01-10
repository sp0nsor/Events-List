using Microsoft.OpenApi.Models;

namespace Events.Application.Contracts.Events
{
    public record EventsPageResponse(
        List<GetEventResponse> Items, 
        int TotalCount,
        int CurrentPage,
        int PageSize,
        int TotalPage);
}
