using AutoMapper;
using BingSafety.Application.Contracts.Persistence;
using BingSafety.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.EmergencyEvents.Commands.UpdateEmergencyEvent {
    public class UpdateEmergencyEventCommandHandler : IRequestHandler<UpdateEmergencyEventCommand> {
        private readonly IAsyncRepository<EmergencyEvent> _emergencyEventRepository;
        private readonly IMapper _mapper;

        public UpdateEmergencyEventCommandHandler(IAsyncRepository<EmergencyEvent> emergencyEventRepository, IMapper mapper) {
            _emergencyEventRepository = emergencyEventRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateEmergencyEventCommand request, CancellationToken cancellationToken) {
            var emergencyEventToUpdate = await _emergencyEventRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, emergencyEventToUpdate, typeof(UpdateEmergencyEventCommand), typeof(EmergencyEvent));

            await _emergencyEventRepository.UpdateAsync(emergencyEventToUpdate);
        }
    }
}
