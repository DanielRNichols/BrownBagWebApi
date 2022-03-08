using NET6.Shared.Interfaces;

namespace NET6.WebApi.Repositories
{
    public interface IBaseDbRepository<T> where T : class, IDbResource
    {
        Task<IList<T>?> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<int> AddAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);
    }
}
