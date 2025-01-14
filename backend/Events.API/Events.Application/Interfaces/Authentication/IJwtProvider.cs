using Events.Core.Models;

namespace Events.Application.Authentication
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}