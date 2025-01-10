using Microsoft.OpenApi.Models;

namespace Events.Application.Contracts.Events
{
    public record GetEventRequest(
        string? SearchName,
        string? SearchPlace,
        string? SearchCategory,
        string? SortItem,
        string? SortOrder,
        int Page = 1, 
        int PageSize = 10);
}
