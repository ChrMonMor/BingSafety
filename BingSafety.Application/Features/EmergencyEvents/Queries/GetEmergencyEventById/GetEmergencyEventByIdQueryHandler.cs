
using AutoMapper;
using BingSafety.Application.Contracts.Persistence;
using BingSafety.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.EmergencyEvents.Queries.GetEmergencyEventById {
    public class GetEmergencyEventByIdQueryHandler : IRequestHandler<GetEmergencyEventByIdQuery, EmergencyEventByIdVm> {

        private readonly IAsyncRepository<EmergencyEvent> _emergencyEvent;
        private readonly IMapper _mapper;

        public GetEmergencyEventByIdQueryHandler(IAsyncRepository<EmergencyEvent> emergencyEvent, IMapper mapper) {
            _emergencyEvent = emergencyEvent;
            _mapper = mapper;
        }

        public async Task<EmergencyEventByIdVm> Handle(GetEmergencyEventByIdQuery request, CancellationToken cancellationToken) {
            var getEmergencyEventById = await _emergencyEvent.GetByIdAsync(request.Id);

            var emergencyEventDto = _mapper.Map<EmergencyEventByIdVm>(getEmergencyEventById);

            return emergencyEventDto;
        }
    }
}
