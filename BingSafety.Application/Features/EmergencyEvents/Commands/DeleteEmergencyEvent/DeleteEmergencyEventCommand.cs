using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.EmergencyEvents.Commands.DeleteEmergencyEvent {
    public class DeleteEmergencyEventCommand : IRequest {
        public Guid Id { get; set; }
    }
}
