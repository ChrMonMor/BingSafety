using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.EmergencyEvents.Commands.UpdateEmergencyEvent {
    public class UpdateEmergencyEventCommand : IRequest {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public Guid Status { get; set; }
    }
}
