using BingSafety.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Contracts.Persistence {
    public interface IEventStatusRepository : IAsyncRepository<EventStatus> {
    }
}
