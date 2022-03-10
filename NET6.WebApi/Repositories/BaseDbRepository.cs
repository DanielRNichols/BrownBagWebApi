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

        protected IDbConnection GetConnection()
        {
            if (_dbConfig.GetConnection == null)
                throw new Exception("Connection method not defined");

            return _dbConfig.GetConnection();
        }

        protected string GetSelectStatement(string tableName, QueryOptions? queryOptions)
        {
            if (_dbConfig.GetSelectStatement == null)
                throw new Exception("GetSelectStatement method not defined");

            return _dbConfig.GetSelectStatement(tableName, queryOptions);
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

        // Base GetAllAsync does not deal with QueryOptions, must override to get this functionality
        public virtual async Task<IList<T>?> GetAllAsync(QueryOptions? queryOptions = null)
        {
            using var dbConn = GetConnection();
            var items = await dbConn.GetAllAsync<T>();

            return items.ToList();
        }

        // Base GetAllAsync does not deal with QueryOptions, must override to get this functionality
        public virtual async Task<T?> GetByIdAsync(int id, bool includeRelated = false)
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
