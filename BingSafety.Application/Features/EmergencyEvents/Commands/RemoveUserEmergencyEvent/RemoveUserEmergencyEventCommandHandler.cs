using AutoMapper;
using BingSafety.Application.Contracts.Persistence;
using BingSafety.Application.Features.EmergencyEvents.Commands.DeleteEmergencyEvent;
using BingSafety.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.EmergencyEvents.Commands.RemoveUserEmergencyEvent {
    public class RemoveUserEmergencyEventCommandHandler : IRequestHandler<RemoveUserEmergencyEventCommand> {
        private readonly IEmergencyEventRepository _emergencyEventRepository;
        private readonly IMapper _mapper;

        public RemoveUserEmergencyEventCommandHandler(IEmergencyEventRepository emergencyEventRepository, IMapper mapper) {
            _emergencyEventRepository = emergencyEventRepository;
            _mapper = mapper;
        }

        public async Task Handle(RemoveUserEmergencyEventCommand request, CancellationToken cancellationToken) {
            var emergencyEventToDelete = await _emergencyEventRepository.ListAllAsync();
            await _emergencyEventRepository.RemoveUser(emergencyEventToDelete.Where(x => x.UserId == request.UserId).ToList());
        }
    }
}
