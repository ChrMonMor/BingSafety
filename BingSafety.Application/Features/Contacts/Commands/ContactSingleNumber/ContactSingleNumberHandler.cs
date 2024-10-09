using AutoMapper;
using BingSafety.Application.Contracts.Persistence;
using BingSafety.Application.Features.EmergencyEvents.Commands.CreateEmergencyEvent;
using MediatR;

namespace BingSafety.Application.Features.Contacts.Commands.ContactSingleNumber {
    public class ContactSingleNumberHandler : IRequestHandler<ContactSingleNumberCommand, ContactSingleNumberCommandResponse> {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactSingleNumberHandler(IContactRepository contactRepository, IMapper mapper) {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<ContactSingleNumberCommandResponse> Handle(ContactSingleNumberCommand request, CancellationToken cancellationToken) {
            var contactSingleNumberCommandResponse = new ContactSingleNumberCommandResponse();

            var validator = new ContactSingleNumberValidator(_contactRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count() > 0) {
                contactSingleNumberCommandResponse.Success = false;
                contactSingleNumberCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validatorResult.Errors) {
                    contactSingleNumberCommandResponse
                        .ValidationErrors.Add(error.ErrorMessage);
                }
            }

            await _contactRepository.SingleNumber(request.PhoneNumber, request.Message);

            return contactSingleNumberCommandResponse;

        }
    }
}
