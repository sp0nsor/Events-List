using Microsoft.AspNetCore.Mvc;
using MediatR;
using Events.Application.Comands.Participants.CreateParticipant;
using Events.Application.Comands.Participants.GetParticipants;
using Events.Application.Comands.Participants.GetParticipantById;
using Events.Application.Comands.Participants.DeleteParticipant;

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
        public async Task<ActionResult> CreateParticipant([FromBody] CreateParticipantCommand command)
        {
            await mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetParticipants([FromQuery] GetParticipantsCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetParticipantById([FromQuery] GetParticipantByIdCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteParticipant([FromQuery] DeleteParticipantCommand command)
        {
            await mediator.Send(command);

            return Ok();
        }
    }
}
