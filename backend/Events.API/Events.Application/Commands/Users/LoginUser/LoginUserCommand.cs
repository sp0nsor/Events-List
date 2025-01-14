using MediatR;

namespace Events.Application.Commands.Users.LoginUser
{
    public record LoginUserCommand(
        string Email,
        string Password) : IRequest<string>;
}
