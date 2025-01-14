using Microsoft.AspNetCore.Mvc;
using MediatR;
using Events.Application.Comands.Registrations.CreateRegistration;
using Events.Application.Comands.Registrations.DeleteRegistration;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationsController : ControllerBase
    {
        private readonly IMediator mediator;

        public RegistrationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateRegistration([FromBody] CreateRegistrationCommand command)
        {
            await mediator.Send(command);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRegistration([FromQuery] DeleteRegistrationCommand command)
        {
            await mediator.Send(command);

            return Ok();
        }
    }
}
