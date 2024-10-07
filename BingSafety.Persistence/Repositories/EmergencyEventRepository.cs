using Amazon.SecurityToken.Model.Internal.MarshallTransformations;
using BingSafety.Application.Contracts.Persistence;
using BingSafety.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Persistence.Repositories {
    public class EmergencyEventRepository(BingSafetyDbContext dbContext) : BaseRepository<EmergencyEvent>(dbContext), IEmergencyEventRepository {
        public async Task<List<EmergencyEvent>> ListAllAsync() {
            return await _dbContext.Set<EmergencyEvent>().ToListAsync();
        }

        public async Task RemoveUser(List<EmergencyEvent> user) {
            for (int i = 0; i < user.Count(); i++) {
                _dbContext.Remove(user[i]);
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
