using BingSafety.Application.Features.EmergencyEvents.Commands.CreateEmergencyEvent;
using BingSafety.Application.Features.EmergencyEvents.Queries.GetEmergencyEventList;
using BingSafety.Application.Features.EventStatuses.Commands.CreateEventStatus;
using BingSafety.Application.Features.EventStatuses.Queries.GetEventStatusList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BingSafety.Api.Controllers {
    [Route("api/[Controller]")]
    [ApiController]
    public class EventStatusController : ControllerBase {
        private readonly IMediator _mediator;
        public EventStatusController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllEventStatuses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EventStatusListVm>>> GetAllEventStatuses() {
            var dtos = await _mediator.Send(new GetEventStatusListQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddEventStatus")]
        public async Task<ActionResult<CreateEventStatusCommand>> Create([FromBody] CreateEventStatusCommand createEventStatusCommand) {
            var response = await _mediator.Send(createEventStatusCommand);
            return Ok(response);
        }
    }
}
