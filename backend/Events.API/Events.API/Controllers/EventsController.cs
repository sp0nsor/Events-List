using Events.Application.Comands.Events.CreateEvent;
using Events.Application.Comands.Events.UpdateEvent;
using Events.Application.Commands.Events.DeleteEvent;
using Events.Application.Queries.Events.GetEventById;
using Events.Application.Queries.Events.GetEventParticipants;
using Events.Application.Queries.Events.GetEvents;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IValidator<CreateEventCommand> createValidator;

        public EventsController(
            IMediator mediator,
            IValidator<CreateEventCommand> createValidator)
        {
            this.mediator = mediator;
            this.createValidator = createValidator;
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult> CreateEvent([FromForm] CreateEventCommand command)
        {
            var validationResult = await createValidator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        [Authorize(Policy = "UserPolicy")]
        public async Task<ActionResult> GetEvents([FromQuery] GetEventsQuery command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("Participants")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<ActionResult> GetEventParticipants([FromQuery] GetEventParticipantsQuery command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("id")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<ActionResult> GetEventById([FromQuery] GetEventByIdQuery command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult> UpdateEvent([FromBody] UpdateEventCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult> DeleteEvent([FromQuery] DeleteEventCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }
    }
}
