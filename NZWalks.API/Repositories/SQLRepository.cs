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
        public async Task<List<T>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
                                                string? sortBy = null, bool isAscending = true,
                                                int pageNumber = 1, int pageSize = 1000)
        {
            var list = new List<T>();

            if (typeof(T) == typeof(Walk))
                list = await dbSet.Include("Difficulty").Include("Region").AsQueryable<T>().ToListAsync();
            else
                list = await dbSet.AsQueryable<T>().ToListAsync();

            //Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                var propertyInfo = typeof(T).GetProperty(filterOn, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (propertyInfo != null)
                    list = list.Where(x => propertyInfo.GetValue(x, null).ToString().Contains(filterQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            //Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                var propertyInfo = typeof(T).GetProperty(sortBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (propertyInfo != null)
                {
                    if (isAscending == true)
                        list = list.OrderBy(x => propertyInfo.GetValue(x, null)).ToList();
                    else
                        list = list.OrderByDescending(x => propertyInfo.GetValue(x, null)).ToList();
                } 
            }

            //Pagination
            var skipResults = (pageNumber -1) * pageSize;
            list = list.Skip(skipResults).Take(pageSize).ToList();

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