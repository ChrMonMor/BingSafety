using AutoMapper;
using BingSafety.Application.Contracts.Persistence;
using BingSafety.Application.Features.EmergencyEvents.Queries.GetEmergencyEventList;
using BingSafety.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.EventStatuses.Queries.GetEventStatusList
{
    public class GetEventStatusListQueryHandler : IRequestHandler<GetEventStatusListQuery, List<EventStatusListVm>>
    {
        private readonly IAsyncRepository<EventStatus> _eventStatus;
        private readonly IMapper _mapper;

        public GetEventStatusListQueryHandler(IAsyncRepository<EventStatus> eventStatus, IMapper mapper)
        {
            _eventStatus = eventStatus;
            _mapper = mapper;
        }

        public async Task<List<EventStatusListVm>> Handle(GetEventStatusListQuery request, CancellationToken cancellationToken)
        {

            var allEmergencyEvents = (await _eventStatus.ReadOnlyListAllAsync()).OrderBy(x => x.Title);

            return _mapper.Map<List<EventStatusListVm>>(allEmergencyEvents);
        }
    }
}
