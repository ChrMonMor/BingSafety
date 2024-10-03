using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.EmergencyEvents.Queries.GetEmergencyEventById {
    public class GetEmergencyEventByIdQuery : IRequest<EmergencyEventByIdVm> {
        public Guid Id { get; set; }
    }
}
