using NET6.Shared.Interfaces;
using NET6.WebApi.Database;

namespace NET6.WebApi.Repositories
{
    public interface IBaseDbRepository<T> where T : class, IDbResource
    {
        Task<IList<T>?> GetAllAsync(QueryOptions? queryOptions = null);
        Task<T?> GetByIdAsync(int id, bool includeRelated = false);
        Task<int> AddAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);
    }
}
