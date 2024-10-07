using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Features.EmergencyEvents.Queries.GetEmergencyEventById {
    public class EmergencyEventByIdVm {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
