using AutoMapper;
using BingSafety.Application.Contracts.Persistence;
using BingSafety.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.EmergencyEvents.Commands.DeleteEmergencyEvent {
    public class DeleteEmergencyEventCommandHandler : IRequestHandler<DeleteEmergencyEventCommand> {
        private readonly IAsyncRepository<EmergencyEvent> _emergencyEventRepository;
        private readonly IMapper _mapper;

        public DeleteEmergencyEventCommandHandler(IAsyncRepository<EmergencyEvent> emergencyEventRepository, IMapper mapper) {
            _emergencyEventRepository = emergencyEventRepository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteEmergencyEventCommand request, CancellationToken cancellationToken) {
            var emergencyEventToDelete = await _emergencyEventRepository.GetByIdAsync(request.Id);
            await _emergencyEventRepository.DeleteAsync(emergencyEventToDelete);
        }
    }
}
