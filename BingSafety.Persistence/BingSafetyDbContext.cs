using BingSafety.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Persistence {
    public class BingSafetyDbContext : DbContext {
        public BingSafetyDbContext(DbContextOptions options) : base(options) {
        }

        public DbSet<EmergencyEvent> EmergencyEvents { get; set; }
        public DbSet<EventStatus> EventStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BingSafetyDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmergencyEvent>().ToCollection("EmergencyEvents");
            modelBuilder.Entity<EventStatus>().ToCollection("EventStatuses");
        }

    }
}
