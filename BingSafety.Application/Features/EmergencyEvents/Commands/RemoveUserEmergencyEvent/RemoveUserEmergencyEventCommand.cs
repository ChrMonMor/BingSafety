using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.EmergencyEvents.Commands.RemoveUserEmergencyEvent {
    public class RemoveUserEmergencyEventCommand : IRequest{
        public Guid UserId {  get; set; } 
    }
}
