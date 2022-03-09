using NET6.Shared.Models;
using NET6.WebApi.Database;

namespace NET6.WebApi.Repositories
{
    public class SessionsPresentersRepository : BaseDbRepository<SessionsPresenters>, ISessionsPresentersRepository
    {
        public SessionsPresentersRepository(BrownBagConnection dbConfig) : base(dbConfig)
        {
        }
    }
}
