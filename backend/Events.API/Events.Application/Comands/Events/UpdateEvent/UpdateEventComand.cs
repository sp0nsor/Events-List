using MediatR;

namespace Events.Application.Comands.Events.UpdateEvent
{
    public record UpdateEventComand(
        Guid Id,
        string Name,
        string Description,
        string Place,
        string Category,
        int MaxParticipant,
        DateTime Date) : IRequest;
}
