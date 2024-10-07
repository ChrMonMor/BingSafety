using MediatR;

namespace BingSafety.Application.Features.EmergencyEvents.Queries.GetEmergencyEventList
{
    public class EmergencyEventListVm {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid Status { get; set; }
    }
}