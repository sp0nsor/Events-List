using Events.Application.Interfaces;
using Events.API.Contracts.Registrations;
using Events.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationsService registrationsService;

        public RegistrationsController(IRegistrationsService registrationsService)
        {
            this.registrationsService = registrationsService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateRegistration([FromBody] CreateRegistrationRequest request)
        {
            var registration = Registration.Create(Guid.NewGuid(), request.EventId, request.ParticipantId);

            await registrationsService.CreateRegistration(registration);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRegistration([FromRoute] Guid id)
        {
            await registrationsService.DeleteRegistration(id);

            return Ok();
        }
    }
}
