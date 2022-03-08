using Microsoft.Data.SqlClient;
using NET6.Shared.Interfaces;
using Dapper.Contrib.Extensions;
using System.Data;

namespace NET6.WebApi.Repositories
{
    public class BaseDbRepository<T> : IBaseDbRepository<T> where T : class, IDbResource, new()
    {
        private readonly Func<IDbConnection> _connectionDelegate;

        public BaseDbRepository(Func<IDbConnection> connectionDelegate)
        {
            _connectionDelegate = connectionDelegate;
        }

        private IDbConnection Connection => _connectionDelegate();

        public async Task<int> AddAsync(T item)
        {
            using var dbConn = Connection;
            var id = await dbConn.InsertAsync(item);

            return id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var dbConn = Connection;
            var success = await dbConn.DeleteAsync<T>(new T { Id = id });

            return success;
        }

        public async Task<IList<T>?> GetAllAsync()
        {
            using var dbConn = Connection;
            var items = await dbConn.GetAllAsync<T>();

            return items.ToList();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            using var dbConn = Connection;
            var item = await dbConn.GetAsync<T>(id);

            return item;
        }

        public async Task<bool> UpdateAsync(T item)
        {
            using var dbConn = Connection;
            var success = await dbConn.UpdateAsync<T>(item);

            return success;
        }
    }
}
