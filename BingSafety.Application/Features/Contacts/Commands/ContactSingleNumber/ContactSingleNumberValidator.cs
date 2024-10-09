using BingSafety.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.Contacts.Commands.ContactSingleNumber {
    public class ContactSingleNumberValidator : AbstractValidator<ContactSingleNumberCommand> {
        private readonly IContactRepository _contactRepository;
        public ContactSingleNumberValidator(IContactRepository contactRepository) { 
            _contactRepository = contactRepository;
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}
