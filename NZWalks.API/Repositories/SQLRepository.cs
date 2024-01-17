using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;

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
            var list = new List<T>();

            if (typeof(T) == typeof(Walk))
                list = await dbSet
                    .Include("Difficulty")
                    .Include("Region")
                    .ToListAsync();
            else
                list = await dbSet.ToListAsync();

            return list;
        }

        // TODO: Use Include to add the navigation properties to the response
        public async Task<T?> GetAsync(Guid id)
        {
            T obj;
            if (typeof(T) == typeof(Walk))
            {
                var walkDbSet = dbSet as IQueryable<Walk>;

                obj = (T)(object)await walkDbSet
                    .Include("Difficulty")
                    .Include("Region")
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            else
                obj = await dbSet.FindAsync(id);
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