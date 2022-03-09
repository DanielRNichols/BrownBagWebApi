using NET6.Shared.Models;
using NET6.WebApi.Database;

namespace NET6.WebApi.Repositories
{
    public class SessionsRepository : BaseDbRepository<Session>, ISessionsRepository
    {
        public SessionsRepository(BrownBagConnection dbConfig) : base(dbConfig)
        {

        }
    }
}
