﻿using BingSafety.Application.Contracts.Persistence;
using BingSafety.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Persistence.Repositories {
    public class ContactRepository(BingSafetyDbContext context) : BaseRepository<Contact>(context), IContactRepository {
    }
}
