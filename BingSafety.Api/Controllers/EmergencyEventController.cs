using BingSafety.Application.Features.EmergencyEvents.Commands.CreateEmergencyEvent;
using BingSafety.Application.Features.EmergencyEvents.Commands.DeleteEmergencyEvent;
using BingSafety.Application.Features.EmergencyEvents.Commands.RemoveUserEmergencyEvent;
using BingSafety.Application.Features.EmergencyEvents.Commands.UpdateEmergencyEvent;
using BingSafety.Application.Features.EmergencyEvents.Queries.GetEmergencyEventById;
using BingSafety.Application.Features.EmergencyEvents.Queries.GetEmergencyEventList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BingSafety.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyEventController : ControllerBase {
        private readonly IMediator _mediator;

        public EmergencyEventController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllEmergencyEvnets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmergencyEventListVm>>> GetAllEmergencyEvents() {
            var dtos = await _mediator.Send(new GetEmergencyEventsListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetEmergencyEventById")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EmergencyEventByIdVm>> GetEmergencyEventById(Guid id) {
            GetEmergencyEventByIdQuery query = new GetEmergencyEventByIdQuery() { Id = id };

            var dtos = await _mediator.Send(query);
            return Ok(dtos);
        }
        [HttpPost(Name = "AddEmergencyEvent")]
        public async Task<ActionResult<CreateEmergencyEventCommand>> Create([FromBody] CreateEmergencyEventCommand createEmergencyEventCommand) {
            var response = await _mediator.Send(createEmergencyEventCommand);
            return Ok(response);
        }
        [HttpPut(Name = "UpdateEmergencyEvent")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateEmergencyEventCommand updateEmergencyEventCommand) {
            await _mediator.Send(updateEmergencyEventCommand);
            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeleteEmergencyEvent")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id) {
            var deleteEmergencyEventCommand = new DeleteEmergencyEventCommand() { Id = id };
            await _mediator.Send(deleteEmergencyEventCommand);
            return NoContent();
        }
        [HttpDelete("remove/{id}", Name = "RemoveUser")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> RemoveUser(Guid id) {
            var removeUserEmergencyEventCommand = new RemoveUserEmergencyEventCommand() { UserId = id };
            await _mediator.Send(removeUserEmergencyEventCommand);
            return NoContent();
        }
    }
}
