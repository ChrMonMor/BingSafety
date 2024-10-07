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
    public class CreateEmergencyEventHandler : IRequestHandler<CreateEmergencyEventCommand, CreateEmergencyEventCommandResponse> {

        private readonly IEmergencyEventRepository _emergencyEventRepository;
        private readonly IMapper _mapper;

        public CreateEmergencyEventHandler(IEmergencyEventRepository emergencyEventRepository, IMapper mapper) {
            _emergencyEventRepository = emergencyEventRepository;
            _mapper = mapper;
        }

        public async Task<CreateEmergencyEventCommandResponse> Handle(CreateEmergencyEventCommand request, CancellationToken cancellationToken) {
             var createEmergencyEventCommandResponse = new CreateEmergencyEventCommandResponse();

            var validator = new CreateEmergencyEventValidator(_emergencyEventRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count() > 0) {
                createEmergencyEventCommandResponse.Success = false;
                createEmergencyEventCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validatorResult.Errors) {
                    createEmergencyEventCommandResponse
                        .ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var emergencyEvent = _mapper.Map<EmergencyEvent>(request);

            emergencyEvent = await _emergencyEventRepository.AddAsync(emergencyEvent);

            return createEmergencyEventCommandResponse;
        }
    }
}
