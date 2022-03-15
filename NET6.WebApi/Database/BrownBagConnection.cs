
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
                var sql = $"SELECT * FROM {tableName}";

                if (queryOptions == null)
                    return sql;

                if (!String.IsNullOrWhiteSpace(queryOptions.Filter))
                    sql = $"{sql} WHERE {queryOptions.Filter}";

                sql = $"{sql} ORDER BY {queryOptions.OrderBy}";

                if (queryOptions.Skip > 0 || queryOptions.Limit > 0)
                    sql = $"{sql} OFFSET {queryOptions.Skip} ROWS";

                if (queryOptions.Limit > 0)
                    sql = $"{sql} FETCH NEXT {queryOptions.Limit} ROWS ONLY";


                return sql;
            };

        }
    }
}
