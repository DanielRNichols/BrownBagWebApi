using Dapper;
using NET6.Shared.Models;
using NET6.WebApi.Database;

namespace NET6.WebApi.Repositories
{
    public class SessionsRepository : BaseDbRepository<Session>, ISessionsRepository
    {
        public SessionsRepository(BrownBagConnection dbConfig) : base(dbConfig)
        {
        }

        public override async Task<IList<Session>?> GetAllAsync(QueryOptions? queryOptions)
        {
            var sessions = await GetSessions(queryOptions);
            if (queryOptions == null || !queryOptions.IncludeRelated)
                return sessions;

            foreach (var session in sessions)
            {
                session.Presenters = await GetPresentersForSessions(session);
            }

            return sessions;
        }

        public override async Task<Session?> GetByIdAsync(int id, bool includePresenters)
        {
            var session = await base.GetByIdAsync(id);
            if (session == null || !includePresenters)
                return session;

            session.Presenters = await GetPresentersForSessions(session);

            return session;
        }

        private async Task<IList<Session>> GetSessions(QueryOptions? queryOptions)
        {
            var sql = GetSelectStatement("Sessions", queryOptions);

            using var dbConn = GetConnection();
            var sessions = await dbConn.QueryAsync<Session>(sql);
            return sessions.ToList();

        }

        private async Task<IList<Presenter>> GetPresentersForSessions(Session session)
        {
            using var dbConn = GetConnection();
            var sql = @"SELECT P.*
                        FROM Sessions AS S
                            LEFT JOIN SessionsPresenters AS SP ON S.Id = SP.SessionId
                            LEFT JOIN Presenters AS P ON SP.PresenterId = P.Id
                        WHERE S.Id = @Id";

            var presenters = await dbConn.QueryAsync<Presenter>(sql, session);
            return presenters.ToList();

        }

    }
}
