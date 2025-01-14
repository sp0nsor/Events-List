namespace Events.Application.DTOs
{
    public record EventsPageDto(
        List<EventDto> Items,
        int TotalCount,
        int CurrentPage,
        int PageSize,
        int TotalPage);
}
