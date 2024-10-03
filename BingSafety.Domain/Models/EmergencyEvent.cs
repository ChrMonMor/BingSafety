using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Domain.Models {
    public class EmergencyEvent {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }
        public DateTime UpdatedDate {  get; set; } = DateTime.Now;
        public string Status { get; set; } = string.Empty; 
    }
}
