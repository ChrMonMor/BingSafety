using Azure.Core;
using BingSafety.Application.Contracts.Persistence;
using BingSafety.Domain.Models;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Persistence.Repositories {
    public class ContactRepository(BingSafetyDbContext context) : BaseRepository<Contact>(context), IContactRepository {
        public async Task SingleNumber(string number, string message) {
            // Send message logic in here! (Don't have the time rigth now)
            await Task.Delay(1);

        }
    }
}
