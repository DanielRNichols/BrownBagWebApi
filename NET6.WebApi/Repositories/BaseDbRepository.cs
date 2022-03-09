using Microsoft.Data.SqlClient;
using NET6.Shared.Interfaces;
using Dapper.Contrib.Extensions;
using System.Data;
using NET6.WebApi.Database;

namespace NET6.WebApi.Repositories
{
    public class BaseDbRepository<T> : IBaseDbRepository<T> where T : class, IDbResource, new()
    {
        private readonly BrownBagConnection _dbConfig;

        public BaseDbRepository(BrownBagConnection dbConfig)
        {
            _dbConfig = dbConfig;
        }

        private IDbConnection GetConnection()
        {
            if (_dbConfig.GetConnection == null)
                throw new ArgumentNullException("Connection method not defined");

            return _dbConfig.GetConnection();
        }

        public async Task<int> AddAsync(T item)
        {
            using var dbConn = GetConnection();
            var id = await dbConn.InsertAsync(item);

            return id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var dbConn = GetConnection();
            var success = await dbConn.DeleteAsync<T>(new T { Id = id });

            return success;
        }

        public async Task<IList<T>?> GetAllAsync()
        {
            using var dbConn = GetConnection();
            var items = await dbConn.GetAllAsync<T>();

            return items.ToList();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            using var dbConn = GetConnection();
            var item = await dbConn.GetAsync<T>(id);

            return item;
        }

        public async Task<bool> UpdateAsync(T item)
        {
            using var dbConn = GetConnection();
            var success = await dbConn.UpdateAsync<T>(item);

            return success;
        }
    }
}
