using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Listless.Persistence;

/// <summary>
/// This class is used to register all persistence services.
/// </summary>
public static class PersistenceRegistration
{
    /// <summary>
    /// Registers all persistence services with the DI container.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <param name="persistenceDirectory">The directory to store the database in.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services, string persistenceDirectory) =>
        services.AddDbContext<ListlessContext>(options => options.UseSqlite($"Filename={persistenceDirectory}/Listless.db3"));
}
