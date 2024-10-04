using BingSafety.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Persistence.Configurations {
    public class EmergencyEventConfiguration : IEntityTypeConfiguration<EmergencyEvent> {
        public void Configure(EntityTypeBuilder<EmergencyEvent> builder) {
            builder.ToBson();
        }
    }
}
