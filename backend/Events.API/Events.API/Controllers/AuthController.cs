using Events.Application.Commands.Users.LoginUser;
using Events.Application.Commands.Users.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            await mediator.Send(command);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginUser(
            [FromBody] LoginUserCommand command)
        {
            var token = await mediator.Send(command);

            HttpContext.Response.Cookies.Append("tasty-cookies", token);

            return Ok(token);
        }
    }
}
