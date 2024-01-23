using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
                                                string? sortBy = null, bool isAscending = true,
                                                int pageNumber = 1, int pageSize = 1000);
        Task<T?> GetAsync(Guid id);
        Task CreateAsync(T obj);
        Task UpdateAsync(T obj);
        Task DeleteAsync(T obj);
    }
}