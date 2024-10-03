using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.EmergencyEvents.Queries.GetEmergencyEventList
{
    public class GetEmergencyEventsListQuery : IRequest<List<EmergencyEventListVm>>
    {
    }
}
