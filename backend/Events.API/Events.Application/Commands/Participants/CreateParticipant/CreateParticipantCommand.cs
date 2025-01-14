using MediatR;

namespace Events.Application.Comands.Participants.CreateParticipant
{
    public record CreateParticipantCommand(
        string FirstName,
        string LastName,
        string Email,
        DateTime BirthDate) : IRequest;
}
