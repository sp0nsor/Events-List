using Events.Application.Comands.Events.CreateEvent;
using Events.Application.Comands.Events.DeleteEvent;
using Events.Application.Comands.Events.GetEventById;
using Events.Application.Comands.Events.GetEventParticipants;
using Events.Application.Comands.Events.GetEvents;
using Events.Application.Comands.Events.UpdateEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IMediator mediator;

        public EventsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateEvent([FromForm] CreateEventCommand command)
        {
            await mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetEvents([FromQuery] GetEventsCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("Participants")]
        public async Task<ActionResult> GetEventParticipants([FromQuery] GetEventParticipantsCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetEventById([FromQuery] GetEventByIdCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEvent([FromBody] UpdateEventCommand command)
        {
            await mediator.Send(command);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEvent([FromQuery] DeleteEventCommand command)
        {
            await mediator.Send(command);

            return Ok();
        }
    }
}
