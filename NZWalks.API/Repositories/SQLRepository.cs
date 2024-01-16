using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using System.Collections.Generic;

namespace NZWalks.API.Repositories
{
    public class SQLRepository<T> : IRepository<T> where T : class
    {
        private readonly NZWalksDBContext dbContext;
        protected readonly DbSet<T> dbSet;

        public SQLRepository(NZWalksDBContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }
        public async Task<List<T>> GetAllAsync()
        {
            var list = await dbSet.ToListAsync();
            return list;
        }

        public async Task<T?> GetAsync(Guid id)
        {
            var obj = await dbSet.FindAsync(id);
            return obj;
        }

        public async Task CreateAsync(T obj)
        {
            await dbSet.AddAsync(obj);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T obj)
        {
            dbSet.Update(obj);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T obj)
        {
            dbSet.Remove(obj);
            await dbContext.SaveChangesAsync();
        }
    }
}