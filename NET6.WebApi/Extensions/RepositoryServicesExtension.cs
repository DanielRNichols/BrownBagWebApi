using NET6.WebApi.Database;
using NET6.WebApi.Repositories;

namespace NET6.WebApi.Extensions
{
    public static class RepositoryServicesExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services,
            Action<BrownBagConnection> dbConfig)
        {
            var brownBagDbConfig = new BrownBagConnection();
            dbConfig(brownBagDbConfig);

            if (brownBagDbConfig.GetConnection == null)
                throw new ArgumentException("Connection method is not defined");

            services.AddScoped<BrownBagConnection>(_ => brownBagDbConfig);

            services.AddScoped<IPresentersRepository, PresentersRepository>();
            services.AddScoped<ISessionsRepository, SessionsRepository>();
            services.AddScoped<ISessionsPresentersRepository, SessionsPresentersRepository>();

            return services;
        }
    }
}
