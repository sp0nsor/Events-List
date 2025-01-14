using MediatR;

namespace Events.Application.Commands.Users.RegisterUser
{
    public record RegisterUserCommand(
        string UserName,
        string Email,
        string Password) : IRequest;
}
