using NET6.Shared.Models;
using NET6.WebApi.Database;

namespace NET6.WebApi.Repositories
{
    public class PresentersRepository : BaseDbRepository<Presenter>, IPresentersRepository
    {
        public PresentersRepository(BrownBagConnection dbConfig) : base(dbConfig)
        {

        }
    }
}
