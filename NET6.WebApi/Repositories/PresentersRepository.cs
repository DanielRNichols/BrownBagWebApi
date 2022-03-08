using NET6.Shared.Models;
using System.Data;

namespace NET6.WebApi.Repositories
{
    public class PresentersRepository : BaseDbRepository<Presenter>, IPresentersRepository
    {
        public PresentersRepository(Func<IDbConnection> connectionDelegate) : base(connectionDelegate)
        {

        }
    }
}
