﻿using BingSafety.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Persistence.Repositories {
    public class BaseRepository<T> : IAsyncRepository<T> where T : class {
        protected readonly BingSafetyDbContext _dbContext;

        public BaseRepository(BingSafetyDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity) {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity) {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(Guid id) {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ReadOnlyListAllAsync() {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity) {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
