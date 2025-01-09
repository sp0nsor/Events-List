namespace Events.Application.Contracts.Events
{
    public record GetEventRequest(
        string? SearchName,
        string? SearchPlace,
        string? SearchCategory,
        string? SortItem,
        string? SortOrder);
}
