using BingSafety.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.EmergencyEvents.Commands.CreateEmergencyEvent {
    public class CreateEmergencyEventValidator : AbstractValidator<CreateEmergencyEventCommand> {
        private readonly IEmergencyEventRepository _emergencyEventRepository;
        public CreateEmergencyEventValidator(IEmergencyEventRepository emergencyEventRepository) {
            _emergencyEventRepository = emergencyEventRepository;
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(x => x.CreatedDate)
                .NotNull()
                .GreaterThan(DateTime.Now);
        }
    }
}
