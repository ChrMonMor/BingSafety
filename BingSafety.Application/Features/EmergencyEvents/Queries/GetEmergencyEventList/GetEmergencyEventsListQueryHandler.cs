using AutoMapper;
using BingSafety.Application.Contracts.Persistence;
using BingSafety.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.EmergencyEvents.Queries.GetEmergencyEventList
{
    public class GetEmergencyEventsListQueryHandler : IRequestHandler<GetEmergencyEventsListQuery, List<EmergencyEventListVm>>
    {
        private readonly IAsyncRepository<EmergencyEvent> _emergencyEvent;
        private readonly IMapper _mapper;

        public GetEmergencyEventsListQueryHandler(IMapper mapper, IAsyncRepository<EmergencyEvent> emergencyRepository)
        {
            _mapper = mapper;
            _emergencyEvent = emergencyRepository;
        }
        public async Task<List<EmergencyEventListVm>> Handle(GetEmergencyEventsListQuery request, CancellationToken cancellationToken)
        {
            var allEmergencyEvents = (await _emergencyEvent.ListAllAsync()).OrderBy(x => x.Date);

            return _mapper.Map<List<EmergencyEventListVm>>(allEmergencyEvents);
        }
    }
}
