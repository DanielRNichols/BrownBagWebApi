using NET6.Shared.Models;
using System.Data;

namespace NET6.WebApi.Repositories
{
    public class SessionsPresentersRepository : BaseDbRepository<SessionsPresenters>, ISessionsPresentersRepository
    {
        public SessionsPresentersRepository(Func<IDbConnection> connectionDelegate) : base(connectionDelegate)
        {
        }
    }
}
