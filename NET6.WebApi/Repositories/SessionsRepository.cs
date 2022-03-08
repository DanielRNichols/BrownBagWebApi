using NET6.Shared.Models;
using System.Data;

namespace NET6.WebApi.Repositories
{
    public class SessionsRepository : BaseDbRepository<Session>, ISessionsRepository
    {
        public SessionsRepository(Func<IDbConnection> connectionDelegate) : base(connectionDelegate)
        {

        }
    }
}
