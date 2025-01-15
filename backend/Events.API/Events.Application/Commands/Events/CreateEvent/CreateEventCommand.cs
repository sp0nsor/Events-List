using MediatR;
using Microsoft.AspNetCore.Http;

namespace Events.Application.Comands.Events.CreateEvent
{
    public record CreateEventCommand(
        string Name,
        string Description,
        string Place,
        string Category,
        int MaxParticipantCount,
        DateTime Date,
        IFormFile Image
    ) : IRequest<Guid>;
}
