using System.Data;
using Listless.Core;

namespace Listless;

public static class StartupExtensions
{
    public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services, IDbConnection connection)
    {
        services.AddScoped<Contracts.IListRepository, Persistence.ListRepository>(_ => new Persistence.ListRepository(connection));

        return services;
    }
}