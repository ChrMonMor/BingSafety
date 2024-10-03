using AutoMapper;
using BingSafety.Application.Contracts.Persistence;
using BingSafety.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.EmergencyEvents.Commands.CreateEmergencyEvent {
    public class CreateEmergencyEventHandler : IRequestHandler<CreateEmergencyEventCommand, Guid> {

        private readonly IEmergencyEventRepository _emergencyEventRepository;
        private readonly IMapper _mapper;

        public CreateEmergencyEventHandler(IEmergencyEventRepository emergencyEventRepository, IMapper mapper) {
            _emergencyEventRepository = emergencyEventRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateEmergencyEventCommand request, CancellationToken cancellationToken) {
            var emergencyEvent = _mapper.Map<EmergencyEvent>(request);

            var validator = new CreateEmergencyEventValidator(_emergencyEventRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count() > 0) {
                throw new Exceptions.ValidationException(validatorResult);
            }

            emergencyEvent = await _emergencyEventRepository.AddAsync(emergencyEvent);

            return emergencyEvent.Id;
        }
    }
}
