using Microsoft.OpenApi.Models;

namespace Events.Application.DTOs
{
    public record PageListDto<T>(
        List<T> Items,
        int TotalCount,
        int CurrentPage,
        int PageSize,
        int TotalPages);
}
