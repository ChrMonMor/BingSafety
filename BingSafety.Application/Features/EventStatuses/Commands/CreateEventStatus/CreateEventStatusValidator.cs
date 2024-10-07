using BingSafety.Application.Contracts.Persistence;
using BingSafety.Application.Features.EmergencyEvents.Commands.CreateEmergencyEvent;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.EventStatuses.Commands.CreateEventStatus {
    public class CreateEventStatusValidator : AbstractValidator<CreateEventStatusCommand> {
        private readonly IEventStatusRepository _eventStatusRepository;
        public CreateEventStatusValidator(IEventStatusRepository emergencyEventRepository) {
            _eventStatusRepository = emergencyEventRepository;
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty();
                
        }
    }
}
