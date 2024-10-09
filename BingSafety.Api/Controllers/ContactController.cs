using BingSafety.Application.Features.Contacts.Commands.ContactSingleNumber;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BingSafety.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase {

        private readonly IMediator _mediator;
        public ContactController(IMediator mediator) { 
            _mediator = mediator;
        }
        [HttpPost(Name = "ContactSingleNumber")]
        public async Task<ActionResult> SingleNumber([FromBody] ContactSingleNumberCommand contactSingleNumberCommand) {
            await _mediator.Send(contactSingleNumberCommand);
            return NoContent();
        }
    }
}
