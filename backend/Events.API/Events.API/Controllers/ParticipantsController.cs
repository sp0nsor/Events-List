using Microsoft.AspNetCore.Mvc;
using MediatR;
using Events.Application.Comands.Participants.CreateParticipant;
using Events.Application.Comands.Participants.GetParticipants;
using Events.Application.Comands.Participants.GetParticipantById;
using Events.Application.Comands.Participants.DeleteParticipant;
using Microsoft.AspNetCore.Authorization;
using Events.Core.Enums;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParticipantsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ParticipantsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult> CreateParticipant([FromBody] CreateParticipantCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        [Authorize(Policy = "UserPolicy")]
        public async Task<ActionResult> GetParticipants([FromQuery] GetParticipantsCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("id")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<ActionResult> GetParticipantById([FromQuery] GetParticipantByIdCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult> DeleteParticipant([FromQuery] DeleteParticipantCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }
    }
}
