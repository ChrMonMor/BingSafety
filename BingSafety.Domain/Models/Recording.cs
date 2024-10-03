using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Domain.Models {
    public class Recording {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public string Adress { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    } 
}
