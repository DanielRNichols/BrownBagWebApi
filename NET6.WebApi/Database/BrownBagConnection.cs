
using Microsoft.Data.SqlClient;
using System.Data;

namespace NET6.WebApi.Database
{
    public class BrownBagConnection
    {
        public Func<IDbConnection>? GetConnection { get; set; }
        public void UseSql(string connectionString)
        {
            GetConnection = () => new SqlConnection(connectionString);
        }
    }
}
