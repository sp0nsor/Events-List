using Microsoft.AspNetCore.Mvc;
using MediatR;
using Events.Application.Comands.Registrations.CreateRegistration;
using Events.Application.Comands.Registrations.DeleteRegistration;
using Microsoft.AspNetCore.Authorization;
using Azure;

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
        [Authorize(Policy = "UserPolicy")]
        public async Task<ActionResult> CreateRegistration([FromBody] CreateRegistrationCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Policy = "UserPolicy")]
        public async Task<ActionResult> DeleteRegistration([FromQuery] DeleteRegistrationCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }
    }
}
