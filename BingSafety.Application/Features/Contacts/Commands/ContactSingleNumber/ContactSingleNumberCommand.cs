using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.Contacts.Commands.ContactSingleNumber {
    public class ContactSingleNumberCommand : IRequest<ContactSingleNumberCommandResponse> {
        public string PhoneNumber { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

    }
}
