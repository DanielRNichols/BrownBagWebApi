using Dapper;
using NET6.Shared.Models;
using NET6.WebApi.Database;

namespace NET6.WebApi.Repositories
{
    public class PresentersRepository : BaseDbRepository<Presenter>, IPresentersRepository
    {
        public PresentersRepository(BrownBagConnection dbConfig) : base(dbConfig)
        {

        }

        public override async Task<IList<Presenter>?> GetAllAsync(QueryOptions? queryOptions)
        {
            var presenters = await GetPresenters(queryOptions);
            if (queryOptions == null || !queryOptions.IncludeRelated)
                return presenters;

            foreach (var presenter in presenters)
            {
                presenter.Sessions = await GetSessionsForPresenter(presenter);
            }

            return presenters;
        }

        public override async Task<Presenter?> GetByIdAsync(int id, bool includeSessions)
        {
            var presenter = await base.GetByIdAsync(id);
            if (presenter == null || !includeSessions)
                return presenter;

            presenter.Sessions = await GetSessionsForPresenter(presenter);

            return presenter;
        }

        private async Task<IList<Presenter>> GetPresenters(QueryOptions? queryOptions)
        {
            var sql = GetSelectStatement("Presenters", queryOptions);

            using var dbConn = GetConnection();
            var presenters = await dbConn.QueryAsync<Presenter>(sql);
            return presenters.ToList();
        }

        private async Task<IList<Session>> GetSessionsForPresenter(Presenter presenter)
        {
            using var dbConn = GetConnection();
            var sql = @"SELECT S.*
                        FROM Presenters AS P
                            LEFT JOIN SessionsPresenters AS SP ON P.Id = SP.PresenterId
                            LEFT JOIN Sessions AS S ON SP.SessionId = S.Id
                        WHERE P.Id = @Id";

            var sessions = await dbConn.QueryAsync<Session>(sql, presenter);
            return sessions.ToList();
        }
    }
}
