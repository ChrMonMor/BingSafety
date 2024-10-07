using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.EventStatuses.Commands.CreateEventStatus {
    public class CreateEventStatusCommand {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
