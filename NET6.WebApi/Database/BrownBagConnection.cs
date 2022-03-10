
using Microsoft.Data.SqlClient;
using System.Data;

namespace NET6.WebApi.Database
{
    public class BrownBagConnection
    {
        public Func<IDbConnection>? GetConnection { get; set; }

        public Func<string, QueryOptions?, string>? GetSelectStatement { get; set; }

        public void UseSql(string connectionString)
        {
            GetConnection = () => new SqlConnection(connectionString);

            GetSelectStatement = (tableName, queryOptions) =>
            {
                var sql = $"Select * from {tableName}";
                if (queryOptions == null)
                    return sql;

                if (!String.IsNullOrWhiteSpace(queryOptions.Filter))
                    sql = $"{sql} Where {queryOptions.Filter}";
                if (!String.IsNullOrWhiteSpace(queryOptions.OrderBy))
                    sql = $"{sql} order by {queryOptions.OrderBy}";
                //if(queryOptions.Skip > 0)
                //    sql = $"{sql} top {queryOptions.Skip}";
                //if (queryOptions.Limit > 0)
                //    sql = $"{sql} limit {queryOptions.Limit}";


                return sql;
            };

        }
    }
}
