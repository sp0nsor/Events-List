﻿using Events.Application.Comands.Events.CreateEvent;
using Events.Application.Comands.Events.DeleteEvent;
using Events.Application.Comands.Events.GetEventById;
using Events.Application.Comands.Events.GetEventParticipants;
using Events.Application.Comands.Events.GetEvents;
using Events.Application.Comands.Events.UpdateEvent;
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
        public async Task<ActionResult> GetEvents([FromQuery] GetEventsCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("Participants")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<ActionResult> GetEventParticipants([FromQuery] GetEventParticipantsCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("id")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<ActionResult> GetEventById([FromQuery] GetEventByIdCommand command)
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
