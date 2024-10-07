using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;

namespace BingSafety.Domain.Models {
    [Collection("EmergencyEvents")]
    public class EmergencyEvent {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate {  get; set; } = DateTime.Now;
        public Guid Status { get; set; }
    }
}
