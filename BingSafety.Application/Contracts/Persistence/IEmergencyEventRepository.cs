using BingSafety.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Contracts.Persistence {
    public interface IEmergencyEventRepository : IAsyncRepository<EmergencyEvent> {

        Task<List<EmergencyEvent>> ListAllAsync();
        Task RemoveUser(List<EmergencyEvent> editableList);
    }
}
