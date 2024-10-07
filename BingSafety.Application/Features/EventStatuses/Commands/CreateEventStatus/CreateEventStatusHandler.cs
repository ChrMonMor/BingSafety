using AutoMapper;
using BingSafety.Application.Contracts.Persistence;
using BingSafety.Application.Features.EmergencyEvents.Commands.CreateEmergencyEvent;
using BingSafety.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.EventStatuses.Commands.CreateEventStatus {
    public class CreateEventStatusHandler : IRequestHandler<CreateEventStatusCommand, CreateEventStatusCommandResponse> {

        private readonly IEventStatusRepository _eventStatusRepository;
        private readonly IMapper _mapper;

        public CreateEventStatusHandler(IEventStatusRepository eventStatusRepository, IMapper mapper) {
            _eventStatusRepository = eventStatusRepository;
            _mapper = mapper;
        }

        public async Task<CreateEventStatusCommandResponse> Handle(CreateEventStatusCommand request, CancellationToken cancellationToken) {
            var createEventStatusCommandResponse = new CreateEventStatusCommandResponse();

            var validator = new CreateEventStatusValidator(_eventStatusRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count() > 0) {
                createEventStatusCommandResponse.Success = false;
                createEventStatusCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validatorResult.Errors) {
                    createEventStatusCommandResponse
                        .ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var eventStatus = _mapper.Map<EventStatus>(request);

            eventStatus = await _eventStatusRepository.AddAsync(eventStatus);

            return createEventStatusCommandResponse;
        }
    }
}
